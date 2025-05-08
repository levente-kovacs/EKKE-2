<?php
    require '../config/config.php';

    // Adatok lementése a nézetből
    $id = $_POST['id'];
    $name = $_POST['name'];
    $email = $_POST['emailAddress'];
    $address = $_POST['address'];
    $active = isset($_POST['active']) ? 1 : 0;

    // Amennyiben minden adat megérkezett, a megfelelő adat módosítása az adatbázisban, az új értékek beállítása
    if (isset($id) && isset($name) && isset($email) && isset($address) && isset($active)) {
        $stmt = $connection->prepare("UPDATE users SET name = :name, emailAddress = :emailAddress, address = :address, active = :active WHERE id = :id");
        $stmt->bindParam(':id', $id);
        $stmt->bindParam(':name', $name);
        $stmt->bindParam(':emailAddress', $email);
        $stmt->bindParam(':address', $address);
        $stmt->bindParam(':active', $active);
        if($stmt->execute()) {
            // Sikeres módosítás esetén visszairányít a home-ra
            header("Location: ../index.php?page=home");
        } else {
            // Sikertelen módosítás esetén hibaüzenet
            echo 'Error: User update failed.';
        }
    } else {
        // Hibaüzenet amennyiben nem érkezett meg minden adat
        echo 'Error: Invalid input.';
    }
?>
