package com.redbull.fightvr;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

import com.thalmic.myo.AbstractDeviceListener;
import com.thalmic.myo.DeviceListener;
import com.thalmic.myo.Hub;
import com.thalmic.myo.Myo;
import com.thalmic.myo.Pose;
import com.thalmic.myo.Quaternion;
import com.thalmic.myo.Vector3;
import com.thalmic.myo.XDirection;
import com.thalmic.myo.scanner.ScanActivity;
import com.unity3d.player.UnityPlayer;

import org.json.JSONException;
import org.json.JSONObject;


public class MainActivity extends AppCompatActivity {
    private Toast mToast;
    private Vector3 lastGyro;

    private DeviceListener mListener = new AbstractDeviceListener() {
        @Override
        public void onConnect(Myo myo, long timestamp) {
            myo.unlock(Myo.UnlockType.HOLD);
            Log.d("Test",myo.getName() + " Connected ");
        }

        @Override
        public void onDisconnect(Myo myo, long timestamp) {
            Log.d("Test",myo.getName() + " disconnected ");
        }

        @Override
        public void onPose(Myo myo, long timestamp, Pose pose) {

            //TODO: Do something awesome.
        }

        @Override
        public void onGyroscopeData(Myo myo, long timestamp, Vector3 gyro) {
            Log.d("Test", "onGyroscopeData: " + gyro.x() + " " + gyro.y() + " " + gyro.z());
            double val = Math.abs(gyro.x() - lastGyro.x());

            lastGyro = gyro;
        }

        @Override
        public void onOrientationData(Myo myo, long timestamp, Quaternion rotation) {
            // Calculate Euler angles (roll, pitch, and yaw) from the quaternion.
            float roll = (float) Math.toDegrees(Quaternion.roll(rotation));
            float pitch = (float) Math.toDegrees(Quaternion.pitch(rotation));
            float yaw = (float) Math.toDegrees(Quaternion.yaw(rotation));
            // Adjust roll and pitch for the orientation of the Myo on the arm.
            if (myo.getXDirection() == XDirection.TOWARD_ELBOW) {
                roll *= -1;
                pitch *= -1;
            }
            // Next, we apply a rotation to the text view using the roll, pitch, and yaw.
//            Log.d("Ord", ""+ yaw);// + "" + pitch + " " + yaw);
        }
    };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Intent intent = new Intent(this, ScanActivity.class);
        startActivity(intent);

        lastGyro = new Vector3();

        Hub hub = Hub.getInstance();
        hub.setLockingPolicy(Hub.LockingPolicy.NONE);
//        hub.addListener(mListener);
        if (!hub.init(this, getPackageName())) {

            // We can't do anything with the Myo device if the Hub can't be initialized, so exit.
            Toast.makeText(this, "Couldn't initialize Hub", Toast.LENGTH_SHORT).show();
            finish();
            return;
        }
        // hub.addListener(mListener);
    }

    @Override
    protected void onResume() {
        super.onResume();
        Hub hub = Hub.getInstance();
        hub.addListener(mListener);
    }

    @Override
    protected void onPause() {
        super.onPause();
        Hub hub = Hub.getInstance();
        hub.removeListener(mListener);
    }

    public void sendGyroToUnity(float pitch, float roll, float yaw) {
        JSONObject gyro = new JSONObject();
        JSONObject data = new JSONObject();
        String JsonString = "";
        try {
            data.put("roll", String.valueOf(roll));
            data.put("yaw", String.valueOf(yaw));
            data.put("pitch", String.valueOf(pitch));
            gyro.put("gyro", data);
            JsonString = gyro.toString();
        } catch (JSONException e) {
            e.printStackTrace();
        }
        if (JsonString.equals("")){
            UnityPlayer.UnitySendMessage("","","");
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Hub.getInstance().removeListener(mListener);
        if (isFinishing()) {
            Hub.getInstance().shutdown();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);
        Log.e("", "onCfrea: ");
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        Log.e("", "onOptionsItemSelected: ");
        if (R.id.action_scan == id) {
            onScanActionSelected();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    private void onScanActionSelected() {
        Intent intent = new Intent(this, ScanActivity.class);
        startActivity(intent);
    }
}
