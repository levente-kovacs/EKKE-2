<?php
    // Amennyiben az id megérkezett, a megfelelő adat törlése az adatbázisból
    if (isset($_GET['id'])) {
        save_data($api_url . '/' . $_GET['id'], [], 'DELETE');
        // Visszairányít a home-ra és kilép
        header("Location: index.php?page=home");
        exit();
    }
?>