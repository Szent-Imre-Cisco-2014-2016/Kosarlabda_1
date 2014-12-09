<?php
function kovacs($kapcsolat){

	$sql = "SELECT nev FROM jatekosok WHERE nev LIKE '%Kovács%'";


	$query = $kapcsolat->query($sql);
	return $query;
}