package ca.bart.myapplication;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.view.MotionEvent;

/**
 * Created by 1530119 on 2017-11-07.
 */

public class Laser implements GameObject, Constants
{
    public float timeSinceCreation = 0;

    private Paint blueOutline = new Paint();

    private int touchId = -1;
    public double angle;

    Matrix matrix = new Matrix();

    public Laser(double shipAngle)
    {
        angle = shipAngle;

        blueOutline.setColor(Color.RED);
        blueOutline.setStyle(Paint.Style.STROKE);
        blueOutline.setStrokeWidth(1.f);
    }

    public void update()
    {
        timeSinceCreation += DELTA_TIME;
    }

    public void onDraw(Canvas canvas)
    {

        canvas.save();

        canvas.scale(1, -1);
        canvas.rotate((float)(angle));

        canvas.drawLine(20,0,200,0,blueOutline);

        canvas.restore();
    }

    public boolean onTouchEvent(MotionEvent event)
    {
        return false;
    }


}
