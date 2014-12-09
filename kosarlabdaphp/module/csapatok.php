<?php
function csapatok($kapcsolat){

	$sql = "SELECT nev, id FROM csapat";


	$query = $kapcsolat->query($sql);
	return $query;
}