
<?php
    // Ellenőrizzük, hogy a kérést POST metódussal küldték-e
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        // Lekérjük a felhasználókat
        $users = get_data($api_url);
        
        // Meghatározzuk az új felhasználó azonosítóját: az utolsó felhasználó azonosítója +1
        $id = end($users)['id'] + 1;
        
        // Az új felhasznló adait egy tömbben tároljuk
        $new_user = [
            'id' => strval($id), // Azonosító (string formátumban)
            'name' => $_POST['name'], // Név
            'emailAddress' => $_POST['emailAddress'], // Email cím
            'address' => $_POST['address'], // Cím
            'active' => isset($_POST['active']) ? true : false // Aktív státusz beállítása (true, ha van bejelölve)
        ];
        
        // Elmenti az új felhasználó adatait
        save_data($api_url, $new_user, 'POST');
        
        // Visszairányít a home-ra és kilép a kódból
        header("Location: index.php?page=home");
        exit();
    }
?>


<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Create user</title>
    <link rel="stylesheet" href="assets/font-awesome-4.7.0/css/font-awesome.min.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/bg.css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
</head>
<body>
    <div class="background"></div>
    <h1 class="title display-5 text-center m-5 text-white">
        <i class="fa fa-user-plus" aria-hidden="true"></i><br>
        Create user
    </h1>
    <main class="col-lg-6 col-10">
        <!-- Form az új felhasználó adatainak megadásához bootstrap validálással -->
        <form class="form-control p-4 needs-validation" method="post" action="index.php?page=create" novalidate>
            <div class="mb-3">
                <label for="inputName" class="form-label">Name</label>
                <input type="text" class="form-control" id="inputName" name="name" pattern="^[A-ZÜŰÖŐÓÚÁÉÍ][a-zöőüűóúéáíA-ZÜŰÖŐÓÚÁÉÍ]{3,}(?: [A-ZÜŰÖŐÓÚÁÉÍ][a-zöőüűóúéáíA-ZÜŰÖŐÓÚÁÉÍ]*){0,2}$" required>
                <div class="invalid-feedback">Please enter a valid name.</div>
            </div>
            <div class="mb-3">
                <label for="emailAddress" class="form-label">Email address</label>
                <input type="email" class="form-control" id="emailAddress" name="emailAddress" aria-describedby="emailHelp" required>
                <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                <div class="invalid-feedback">Please enter a valid email address.</div>
            </div>
            <div class="mb-4">
                <label for="address" class="form-label">Address</label>
                <input type="text" class="form-control" id="address" name="address" required>
                <div class="invalid-feedback">Please enter an address.</div>
            </div>
            <div class="d-flex flex-column align-items-center justify-content-center">
                <div class="mb-4 form-check">
                    <input type="checkbox" class="form-check-input" id="active">
                    <label class="form-check-label" for="active" name="active">Active</label>
                </div>
                <button type="submit" class="btn btn-outline-success col-8"><i class="fa fa-save" aria-hidden="true"></i></button>
            </div>
        </form>
    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="../assets/js/bootstrap.formvalidation.js"></script>
</body>
</html>