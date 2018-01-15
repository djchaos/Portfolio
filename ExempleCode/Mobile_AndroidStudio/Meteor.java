package ca.bart.myapplication;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.view.MotionEvent;
import android.util.Log;
import java.util.Random;

/**
 * Created by 1530119 on 2017-11-06.
 */

public class Meteor implements GameObject ,Constants
{

    private Paint blueOutline = new Paint();

    private int touchId = -1;

    public double angle;
    public int nbCoter;
    public float impactDistance;
    private int rotate = 0;
    private float speed = 50;

    private Random rnd = new Random();

    private Matrix matrix = new Matrix();

    public Meteor()
    {
        impactDistance = (float)GameView.diag * 1.2f;
        switch (rnd.nextInt(6))
        {
            case 0: blueOutline.setColor(Color.RED);
                break;
            case 1: blueOutline.setColor(Color.GREEN);
                break;
            case 2: blueOutline.setColor(Color.argb(255,61,77,141));//mauve
                break;
            case 3: blueOutline.setColor(Color.argb(255,247,211,27));//dark yellow
                break;
            case 4: blueOutline.setColor(Color.argb(255,255,51,255));//rose
                break;
            case 5: blueOutline.setColor(Color.CYAN);
                break;
        }
        blueOutline.setStyle(Paint.Style.FILL);
        blueOutline.setStrokeWidth(0.7f);

        nbCoter = rnd.nextInt(4)+5;

        angle = rnd.nextInt(360);

    }

    public void update()
    {
        impactDistance -= (float)DELTA_TIME * speed;
        rotate += (DELTA_TIME * (360*2));
    }

    public void onDraw(Canvas canvas)
    {

        canvas.save();

        canvas.scale(1, -1);
        canvas.getMatrix().invert(matrix);
        canvas.rotate((float)angle);
        canvas.translate(impactDistance,0);
        canvas.rotate((float)(rotate));
        Helper.drawPolygon(canvas, blueOutline, 8, nbCoter);

        canvas.restore();
    }

    public boolean onTouchEvent(MotionEvent event)
    {
        return false ;
    }
}


