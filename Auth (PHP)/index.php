<?php
error_reporting(E_ALL);
require("inc/config.php");
require("inc/tools.php");
require 'inc/MyTXT.php';
$Config = new config();

$user = new MyTXT($Config->Userfile);
$user->delimiter = ":|:";
if(isset($_POST["init"]))
{
	if(in_array($_POST["hwid"],$Config->machineIDs))
	{
		foreach ($log->rows as $row)
		{
			echo $row['user'].":|:".$row['time'].":|:".$row['message']."\r\n";
		}
	}
}

if(isset($_POST["registration"]))
{
	$User = $_POST["user"];$Pass = $_POST["pass"];$Pass=encryptRJ256($Config->ky, $Config->iv, $Pass);
	$user->add_row(array($User, $Pass));$user->save($user->file);exit("registration done");
}

if(isset($_POST["login"]))
{
	$User = $_POST["user"];$Pass = $_POST["pass"];$Pass = encryptRJ256($Config->ky, $Config->iv,$Pass);
	foreach ($user->rows as $row) {if ($row['user'] == $User){if($row["pass"] == $Pass){exit("success");}else{exit("wrong password");}}}
		exit("unkown user");
}
if(isset($_POST["hwid"]) && !isset($_POST[1])){if(in_array($_POST["hwid"],$Config->machineIDs)){exit("hwid found");}else{exit("hwid not found");}}