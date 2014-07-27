<?php

/**
 * @author FreshDev
 *
 */
class config
{
	/**
	 * Usercredentials file as database-altnernative, must have write-rights
	 */
	var $Userfile = "user/user.txt";
	
	/**
	 * Set these to random values
	 */
	var $ky = 'S0M3TH!NG_R4ND0M_H3R3';
	var $iv = '@ND_H3R3_4LS0';
	
	//Allowed HWID's add by hand the allowed one returned from first-run of client. (CPU-Serial) the two inserted are just for demonstration
	var $machineIDs = array(
		"BAEBFBFF000306C1",
		"FFEBFBFF000206D1"
	);
}




?>