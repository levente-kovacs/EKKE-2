<?php
    require '../config/config.php';

    // Paraméterben átadott user id lementése
    $id = $_GET['id'];

    // Amennyiben az id megérkezett, a megfelelő adat törlése az adatbázisból
    if (isset($id)) {
        $stmt = $connection->prepare("DELETE FROM users WHERE id = :id");
        $stmt->bindParam(':id', $id);
        if($stmt->execute()) {
            // Sikeres törtlés esetén visszairányít a home-ra
            header("Location: ../index.php?page=home");
        } else {
            // Sikertelen törtlés esetén hibaüzenet
            echo 'Error: User deletion failed.';
        }
    } else {
        // Hibaüzenet amennyiben nem érkezett meg az id
        echo 'Error: Invalid id.';
    }
?>
