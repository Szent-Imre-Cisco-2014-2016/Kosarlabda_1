<?php
$osszes_lista = osszes_lista($kapcsolat, $_GET["asc"]);
if($osszes_lista->num_rows > 0){
	$elso = 0;
	while ($row = $osszes_lista->fetch_assoc()) {
		if($elso == 0){
			echo $row["nev"];
			$elso = 1;
		}else{
			echo ":".$row["nev"];
		}
	}
}else{
	echo "ERROR:1";
}
