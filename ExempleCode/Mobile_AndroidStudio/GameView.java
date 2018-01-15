package ca.bart.myapplication;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;

import java.util.Iterator;
import java.util.LinkedList;
import java.util.StringTokenizer;

public class GameView extends View implements Constants {

    public static final String TAG = "GameView";

    private LinkedList<GameObject> gameObjects = new LinkedList<>();

    private int cx, cy;
    public static double diag;
    private float scale;
    private Meteor[] meteor = new Meteor[40];
    private Laser[] laser = new Laser[20];
    private Ship ship = new Ship();
    private double Time;
    private int life = 100;
    private int score;
    AlertDialog.Builder alert;
    public boolean paused;


    public GameView(Context context) {
        this(context, null);
    }

    public GameView(Context context, AttributeSet attrs) {
        super(context, attrs);

        gameObjects.add(ship);
        Init();
        alert = new AlertDialog.Builder(context);
    }

    @Override
    protected void onSizeChanged(int w, int h, int oldw, int oldh) {

        cx = w / 2;
        cy = h / 2;
        int min = Math.min(cx, cy);
        scale = min / 100.0f;

        double result = (cx*cx)+(cy*cy);
        diag = Math.sqrt(result);


    }

    @Override
    protected void onDraw(Canvas canvas) {

        canvas.translate(cx, cy);
        canvas.scale(scale, -scale);

        Paint blueOutline = new Paint();
        Paint backGround = new Paint();

        backGround.setColor(Color.BLACK);
        blueOutline.setColor(Color.BLUE);

        //canvas.drawRect(600,600,-600,-600, backGround);

        canvas.drawCircle(0, 0, 10, blueOutline);
        //Helper.drawTriangle(canvas, blueOutline, 80, 30, true);
        //Helper.drawPolygon(canvas, blueOutline, 100, 6);


        for (GameObject gameObject : gameObjects) {
            gameObject.onDraw(canvas);
        }
    }

    public void update() {

        for (GameObject gameObject : gameObjects) {
            gameObject.update();
        }
        if(paused)
        {
            return;
        }
        meteorSpawn();
        meteorRemove();
        removeShoot();
    }

    public void meteorSpawn() {
        float spawnTime = 0.5f;
        Time += DELTA_TIME;
        if (Time >= spawnTime) {
            Time = 0;
            for (int i = 0; i < meteor.length; i++) {
                if (meteor[i] == null) {
                    meteor[i] = new Meteor();
                    gameObjects.add(meteor[i]);
                    break;
                }
            }
        }
    }

    public void meteorRemove() {
        for (int i = 0; i < meteor.length; i++) {
            if (meteor[i] != null && meteor[i].impactDistance <= 0.1f) {
                gameObjects.remove(meteor[i]);
                earthLife(meteor[i]);
                meteor[i] = null;
            }
        }
    }

    public void earthLife(Meteor meteorX) {
        life = life - meteorX.nbCoter;
        if (life <= 0) {
            alert.setTitle("Your Dead")
                    .setMessage("Score:" + String.valueOf(score))
                    .setPositiveButton("play again", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int number) {
                            paused = false;
                            life = 100;
                            Init();
                        }
                    })
                    .setNegativeButton("Exit", new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int number) {
                            System.exit(0);
                            dialog.cancel();
                        }
                    }).setCancelable(false);
            paused = true;
            AlertDialog alertDialog = alert.show();
        }
    }

    public void shoot() {
        for (int i = 0; i < laser.length; i++) {
            if (laser[i] == null) {
                laser[i] = new Laser(ship.angle);
                gameObjects.add(laser[i]);
                break;
            }
        }
    }

    public void removeShoot() {
        for (int i = 0; i < laser.length; i++) {
            if (laser[i] != null && laser[i].timeSinceCreation >= 0.10f) {
                gameObjects.remove(laser[i]);
                laser[i] = null;
            }
        }
    }

    public void destroyMeteor() {
        float realAngle = (float) ship.angle + 360;
        if (realAngle >= 360) {
            realAngle -= 360;
        }

        double ConeMx = realAngle + 5;
        double ConeMi = realAngle - 5;

        for (int j = 0; j < meteor.length; j++) {
            if (meteor[j] != null) {
                if (meteor[j].angle >= ConeMi && meteor[j].angle <= ConeMx) {
                    score++;
                    gameObjects.remove(meteor[j]);
                    meteor[j] = null;
                }
            }
        }
    }

    public void Init()
    {
        for (int i = 0; i < meteor.length; i++)
        {
            if(meteor[i] != null)
            {
                gameObjects.remove(meteor[i]);
                meteor[i] = null;
            }
        }
        for (int i = 0; i < laser.length; i++)
        {
            if(laser[i] != null)
            {
                gameObjects.remove(laser[i]);
                laser[i] = null;
            }
        }
    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        boolean result = false;

        for (Iterator<GameObject> i = gameObjects.descendingIterator(); i.hasNext(); ) {
            GameObject gameObject = i.next();
            if (gameObject.onTouchEvent(event)) {
                result = true;
                break;
            }
        }
        switch (event.getActionMasked()) {
            case MotionEvent.ACTION_DOWN:
            case MotionEvent.ACTION_POINTER_DOWN:
                shoot();
                destroyMeteor();
        }
        return result || super.onTouchEvent(event);
    }

}
