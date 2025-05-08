<?php
    if (isset($_GET['id'])) {
        save_data($api_url . '/' . $_GET['id'], [], 'DELETE');
        header("Location: index.php?page=home");
        exit();
    }
?>