<?php
$hiperaktiv = hiperaktiv($kapcsolat);
if($hiperaktiv->num_rows > 0){
	$elso = 0;
	while ($row = $hiperaktiv->fetch_assoc()) {
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
