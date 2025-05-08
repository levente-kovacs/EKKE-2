<?php
    require './config/config.php';

    // Adatok lekérése az adatbázisból
    $stmt = $connection->prepare("SELECT * FROM users");
    $stmt->execute();
    // Adatok lementése
    $users = $stmt->fetchAll(PDO::FETCH_ASSOC);
?>
