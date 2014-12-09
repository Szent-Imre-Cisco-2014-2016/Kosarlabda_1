<?php
header('Content-Type: text/html; charset=utf-8');
ini_set('display_errors', 'on');
define('DEBUG', true);

// API kulcs ellenőrzése
if(isset($_GET["key"]) && $_GET["key"] == "8Rj3W4nsBN"){
	
	
	// MySQL csatlakozás
	require_once("module/sql.php");
	$sqlk = new SqlKapcsolodas();
	$host = "localhost";
	$user = "root";
	$pass = "";
	$db = "kosarlabda_1";
	$sqlk->sql_kapcsolodas($host, $user, $pass, $db);
	
	// Parancsok
	if(isset($_GET["parancs"])){
			if($_GET["parancs"] == "osszes_lista"){// összes kosárlabdázó játékos neve
				if(isset($_GET["asc"])){
					include('module/osszes_lista.php');
					include('controller/osszes_lista.php');
				}else{
					echo "Hiányzó paraméter: ASC!";
				}
			}
			
			if($_GET["parancs"] == "magas"){ //válogassuk ki egy !csapat! 190 cm-nél magasabb játékosait
				if(isset($_GET["csapat"])){
					include('module/magas.php');
					include('controller/magas.php');
				}else{
					echo "Hiányzó paraméter: csapat!";
				}
			}
			
			if($_GET["parancs"] == "csapatok"){ // csapatok lekérdezése (magashoz kell)
				include('module/csapatok.php');
				include('controller/csapatok.php');
			}
			
			if($_GET["parancs"] == "hiperaktiv"){ //játékosok nevei amelyik mindegyik csapatban játszanak
				include('module/hiperaktiv.php');
				include('controller/hiperaktiv.php');
			}
			
			
			if($_GET["parancs"] == "kovacs"){ //kovács vezetéknevű játékos van-e?
				include('module/kovacs.php');
				include('controller/kovacs.php');
			}
	}
}else{
	echo "Hibás kulcs!";
}