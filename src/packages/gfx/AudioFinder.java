package packages.gfx;

import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.sound.sampled.FloatControl;

import packages.main.Main;

public class AudioFinder {

	private AudioFinder(){}
	
	public static Clip getSound(final String url) {
		Clip clip = null;
		try {
	        clip = AudioSystem.getClip();
	        AudioInputStream inputStream = AudioSystem.getAudioInputStream(AudioFinder.class.getResourceAsStream(url +".wav"));
	        clip.open(inputStream);
			FloatControl volume = (FloatControl) clip.getControl(FloatControl.Type.MASTER_GAIN);
			volume.setValue((float) Main.volume);
	    } catch (Exception e) {
	    	System.err.println(e.getMessage());
	    }
		if (clip == null){
			System.err.println("Audio file not found: " +url);
		}
        return clip;
	}
}