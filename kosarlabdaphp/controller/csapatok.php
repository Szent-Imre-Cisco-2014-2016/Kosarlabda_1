<?php
$csapat = csapatok($kapcsolat);
if($csapat->num_rows > 0){
	$elso = 0;
	while ($row = $csapat->fetch_assoc()) {
		if($elso == 0){
			echo $row["nev"].",".$row["id"];
			$elso = 1;
		}else{
			echo ":".$row["nev"].",".$row["id"];
		}
	}
}else{
	echo "ERROR:1";
}
