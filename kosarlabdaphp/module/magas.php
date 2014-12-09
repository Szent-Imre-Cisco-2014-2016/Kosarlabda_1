<?php
function magas($kapcsolat, $csapat){

	$sql = "SELECT nev FROM jatekosok WHERE magassag > 190 AND csapat LIKE '%".$csapat."%'";


	$query = $kapcsolat->query($sql);
	return $query;
}