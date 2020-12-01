window.addEventListener('load', (event) => {
    const baseUrl = 'http://localhost:51740/api/Breeds/';
    let breeds = [];

    function fetchBreeds() {
        fetch(baseUrl)
            .then(response => {
                if (response.status === 200) {
                    return response.json();
                } else {
                    console.log("something wrong happened");
                    return response.json()
                }
            })
            .then((data) => {
                var BreedHTMLListMapped = data.map(p =>
                    `<div class="col-md-6">
                    <a href="${p.name === "Undeads" | p.name === "Orcs" | p.name === "Humans" | p.name === "NightElves" ? p.name : "Humans"}.html">
                        <div class="image">
                            <img src="images/${p.name === "Undeads" | p.name === "Orcs" | p.name === "Humans" | p.name === "NightElves" ? p.name : "Default"}.jpg" alt="${p.name}">                            
                        </div>
                        <div class="image-title" >
                            <span>${p.name}</span>
                        </div>
                        
                    </a>
                </div>
               `);
                var breedContent = `${BreedHTMLListMapped.join('')}`;
                document.getElementById("breed-list-content").innerHTML = breedContent;
            })

    }

    function fetchGeSingleBreed() {
        let localid = window.location.pathname.split("/")[1].split(".")[0];
        fetch(`${baseUrl}${localid}`)
            .then(response => {
                if (response.status === 200) {
                    return response.json();
                } else {
                    console.log("something wrong happened");
                    return response.json()
                }
            })
            .then((data) => {
                var SingleBreedHtmlMapped = data.map(p =>
                    `<div class="col-md-6">
                        <thead>
                            <tr>
                                <th>Key</th>
                                <th>Value</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Id</td>
                                <td>${p.id}</td>
                            </tr>
                            <tr>
                                <td>Name</td>
                                <td>${p.name}</td>
                            </tr>
                            <tr>
                                <td>TypesOfUnity</td>
                                <td>${p.typesOfUnity}</td>
                            </tr>
                            <tr>
                                <td>DefaultColor</td>
                                <td>${p.defaultColor}</td>
                            </tr>
                            <tr>
                                <td>Reign</td>
                                <td>${p.reign}</td>
                            </tr>
                            <tr>
                                <td>ArmyName</td>
                                <td>${p.armyName}</td>
                            </tr>
                            <tr>
                                <td>Difficulty</td>
                                <td>${p.difficulty}</td>
                            </tr>
                            <tr>
                                <td>Rating</td>
                                <td>${p.rating}</td>
                            </tr>
                        </tbody>
                    </div>
               `);
                var SinglebreedContent = `<table class="table table-dark">${SingleBreedHtmlMapped.join('')}</table>`;
                document.getElementById("Singlebreed-list-content").innerHTML = SinglebreedContent;
            });

    }

    function fetchPostBreed(event) {
        console.log(event.currentTarget);
        event.preventDefault();
        var data = {
            name: event.currentTarget.name.value,
            typesOfUnity: parseInt(event.currentTarget.typesOfUnity.value),
            defaultColor: event.currentTarget.defaultColor.value,
            reign: event.currentTarget.reign.value,
            armyName: event.currentTarget.armyName.value,
            difficulty: event.currentTarget.difficulty.value,
            rating: parseFloat(event.currentTarget.rating.value)
        }
        debugger;
        fetch(baseUrl, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'POST',
            body: JSON.stringify(data)
        }).then((response) => {
            debugger;
            if (response.status === 201) {
                console.log("Breed created successfuly");
            } else {
                response.text().then((data) => {
                    debugger;
                    console.log(data);
                });
            }
        }).catch((response) => {
            console.log(data);
        });
    }

    function fetchUpdateBreed(event) {
        var data = {
            name: event.currentTarget.name.value,
            typesOfUnity: parseInt(event.currentTarget.typesOfUnity.value),
            defaultColor: event.currentTarget.defaultColor.value,
            reign: event.currentTarget.reign.value,
            armyName: event.currentTarget.armyName.value,
            difficulty: event.currentTarget.difficulty.value,
            rating: parseFloat(event.currentTarget.rating.value)
        }
        debugger;
        fetch(baseUrl, {
            headers: { "Content-Type": "application/json; charset=utf-8" },
            method: 'PUT',
            body: JSON.stringify(data)
        }).then((response) => {
            debugger;
            if (response.status === 200) {
                console.log("Breed updated successfuly");
            } else {
                response.text().then((data) => {
                    debugger;
                    console.log(data);
                });
            }
        }).catch((response) => {
            console.log(data);
        });
    }

    function fetchDeleteBreed(event) {
        var idToDelete = parseInt(event.currentTarget.id.value);
        fetch(`${baseUrl}${idToDelete}`, {
            method: "DELETE"
        });
    }
    if (document.getElementById("fetch-Btn") != null) {
        document.getElementById("fetch-Btn").addEventListener("click", fetchBreeds);
    }
    if (document.getElementById("fetch-frm") != null) {
        document.getElementById("fetch-frm").addEventListener("submit", fetchPostBreed);
    }
    if (document.getElementById("fetch-update-frm") != null) {
        document.getElementById("fetch-update-frm").addEventListener("submit", fetchUpdateBreed);
    }
    if (document.getElementById("fetch-delete-Btn") != null) {
        document.getElementById("fetch-delete-Btn").addEventListener("click", fetchDeleteBreed);
    }
    if (document.getElementById("fetch-Single-Btn") != null) {
        document.getElementById("fetch-Single-Btn").addEventListener("click", fetchGeSingleBreed);
    }



    //.then(json => console.log(json))
});



/*
<div class="col-md-3">
                    <label for="name">Name</label>
                </div>
                <div class="col-md-7">
                    <input type="text" name="name" id="form-name">
                </div>
                <div class="col-md-3">
                    <label for="typesOfUnity">Types Of Unitys</label>
                </div>
                <div class="col-md-7">
                    <input type="number" name="typesOfUnity" id="form-age">
                </div>
                <div class="col-md-3">
                    <label for="defaultColor">Default Color</label>
                </div>
                <div class="col-md-7">
                    <input type="text" name="defaultColor" id="form-defaultColor">
                </div>
                <div class="col-md-3">
                    <label for="reign">Reign</label>
                </div>
                <div class="col-md-7">
                    <input type="text" name="reign" id="form-reign">
                </div>
                <div class="col-md-3">
                    <label for="armyName">Army Name</label>
                </div>
                <div class="col-md-7">
                    <input type="text" name="armyName" id="form-armyName">
                </div>
                <div class="col-md-3">
                    <label for="difficulty">Difficulty</label>
                </div>
                <div class="col-md-7">
                    <input type="text" name="difficulty" id="form-difficulty">
                </div>
                <div class="col-md-3">
                    <label for="rating">Rating</label>
                </div>

                <div class="col-md-7">
                    <input type="number" name="rating" id="form-rating">
                </div>
                <div class="col-md-12">
                    <input type="submit" value="submit">
                </div>
                */




/*


            <label for="name">Name</label>

            <input type="text" name="name" id="form-name">

            <label for="typesOfUnity">Types Of Unitys</label>

            <input type="number" name="typesOfUnity" id="form-age">

            <label for="defaultColor">Default Color</label>

            <input type="text" name="defaultColor" id="form-defaultColor">

            <label for="reign">Reign</label>

            <input type="text" name="reign" id="form-reign">

            <label for="armyName">Army Name</label>

            <input type="text" name="armyName" id="form-armyName">
            <label for="difficulty">Difficulty</label>

            <input type="text" name="difficulty" id="form-difficulty">

            <label for="rating">Rating</label>

            <input type="number" name="rating" id="form-rating">

            <input type="submit" value="submit">*/