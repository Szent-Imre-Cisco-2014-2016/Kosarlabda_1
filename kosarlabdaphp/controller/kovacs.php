<?php
$kovacs = kovacs($kapcsolat);
if($kovacs->num_rows > 0){
	$elso = 0;
	while ($row = $kovacs->fetch_assoc()) {
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
