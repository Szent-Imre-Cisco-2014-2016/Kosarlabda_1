<?php
function hiperaktiv($kapcsolat){
	
	$sql = "SELECT id FROM csapat";
	$query = $kapcsolat->query($sql);
	
	if($query->num_rows>0){
		$csapatszamok = "";
		while ($row = $query->fetch_assoc()) {
			$csapatszamok = $csapatszamok."%".$row["id"]; 
		}
		$sqla = "SELECT nev FROM jatekosok WHERE magassag > 190 AND csapat LIKE '".$csapatszamok."'";
	
	
		$querya = $kapcsolat->query($sqla);
		return $querya;
	}else{
		return $query;
	}
}