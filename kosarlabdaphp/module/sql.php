<?php
class SqlKapcsolodas{
	function sql_kapcsolodas($host, $user, $pass, $db){

		$kapcsolat = mysqli_connect($host,$user,$pass,$db);
		if ($kapcsolat->connect_error){
  			die('Nem sikerült kapcsolódni: ' . $kapcsolat->connect_error);
  		}else{
  			$GLOBALS["kapcsolat"] = $kapcsolat;
  		}

   			$kapcsolat->query("SET NAMES UTF8");
			$kapcsolat->query("SET collation_connection = 'utf8'");
		
	}
}
?>