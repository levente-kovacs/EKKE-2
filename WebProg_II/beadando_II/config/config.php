<?php
    // Adatbáziskapcsolathoz szükséges adatok
    $host = "localhost"; // Adatábzis elérhetősége
    $uname = "root"; // Alapértelmezett XAMPP felhasználó
    $pw = ""; // Alapértelmezett XAMPP jelszó
    $db = "webprog_rest_api"; // Adatbázis neve

    try {
        // PDO driverrel való kapcsolódás az adatbázishoz
        $connection = new PDO("mysql:host=$host;dbname=$db", $uname, $pw);
        
        // Hibakezelés
        $connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch(PDOException $ex) {
        // Hiba esetén a kivétel elkapása és a hibaüzenet megjelenítése
        echo "Connection failed: " . $ex->getMessage();
    }
?>