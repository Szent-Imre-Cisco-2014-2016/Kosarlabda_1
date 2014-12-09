<?php
function osszes_lista($kapcsolat, $asc){
	if($asc == 0){
		$sql = "SELECT nev FROM jatekosok"; 
	}else{
		$sql =  "SELECT nev FROM jatekosok ORDER BY nev ASC"; //játékosok nevei névsorban
	}

	$query = $kapcsolat->query($sql);
	return $query;
}