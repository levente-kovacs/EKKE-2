<?php
    $host = "localhost";
    $uname = "root"; // Alapértelmezett XAMPP/WAMP felhasználó
    $pw = ""; // Alapértelmezett XAMPP/WAMP jelszó
    $db = "webprog_rest_api";

    try {
        $connection = new PDO("mysql:host=$host;dbname=$db", $uname, $pw);
        $connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch(PDOException $e) {
        echo "Connection failed: " . $e->getMessage();
    }
?>