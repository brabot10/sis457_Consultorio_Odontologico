//Validación para que solo permita  letras, espacios y la ñ 
function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        } else if (e) {
            var charCode = e.which;
        } else {
            return true;
        }

        // Permito espacios y Ñ
        if (
            (charCode > 64 && charCode < 91) ||
            (charCode > 96 && charCode < 123) ||
            charCode === 32 || // Espacio
            charCode === 209 // Ñ
        ) {
            return true;
        } else {
            return false;
        }
    } catch (err) {
        alert(err.Description);
    }
}

//Validación para que solo permita  solo números
function onlyNumber(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        else
            return true;
    }
    catch (err) {
        alert(err.Description);
    }
}

//Validación para que solo permita  pacientes mayores a un año
function validateDate(event) {
    // Obtén el valor del input
    var inputDate = event.target.value;

    // Intenta analizar la cadena de fecha y hora
    var selectedDate = new Date(inputDate);

    // Verifica si el análisis fue exitoso y la fecha no es "Invalid Date"
    if (!isNaN(selectedDate.getTime())) {
        // Calcula la fecha y hora actual
        var currentDate = new Date();

        // Calcula la diferencia en milisegundos
        var differenceInMilliseconds = currentDate - selectedDate;

        // Calcula la diferencia en años
        var differenceInYears = differenceInMilliseconds / (1000 * 60 * 60 * 24 * 365.25);

        // Realiza la validación, permitiendo solo pacientes mayores de un año
        if (differenceInYears < 1) {
            alert("La fecha de nacimiento del  paciente debe ser mayor a un año.");
            event.target.value = ""; // Limpia el valor del input
        }
    }
    else {
        alert("Por favor, ingresa una fecha y hora válida en el formato dd/mm/yyyy ");
        event.target.value = ""; // Limpia el valor del input
    }
}

//Validación para que solo permita  registros de fechas mayores a la fecha actual 
function validateFutureDate(event) {
    // Obtén el valor del input
    var inputDate = event.target.value;

    // Intenta analizar la cadena de fecha y hora
    var selectedDate = new Date(inputDate);

    // Verifica si el análisis fue exitoso y la fecha no es "Invalid Date"
    if (!isNaN(selectedDate.getTime())) {
        // Calcula la fecha y hora actual
        var currentDate = new Date();

        // Realiza la validación, permitiendo solo fechas futuras
        if (selectedDate <= currentDate) {
            alert("La fecha e hora deben ser posteriores a la fecha y hora actual.");
            event.target.value = ""; // Limpia el valor del input
        }
    }
    else {
        alert("Por favor, ingresa una fecha y hora válida en el formato dd/mm/yyyy ");
        event.target.value = ""; // Limpia el valor del input
    }
}


//function onlyAlphabets(e, t) {
//	try {
//		if (window.event) {
//			var charCode = window.event.keyCode;
//		}
//		else if (e) {
//			var charCode = e.which;
//		}
//		else { return true; }
//		if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))

//			return true;
//		else
//			return false;
//	}
//	catch (err) {
//		alert(err.Description);
//	}
//}
//function onlyAlphabets(e, t) {
//	try {
//		if (window.event) {
//			var charCode = window.event.keyCode;
//		}
//		else if (e) {
//			var charCode = e.which;
//		}
//        else { return true; }

//        if (charCode >= 65 && charCode <= 90 || charCode == 32 || charCode == 8 || charCode == 8 || charCode == 110);
//		/*if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))*/

//			return true;
//		else
//			return false;
//	}
//	catch (err) {
//		alert(err.Description);
//	}
//}
//function validarEdadMinima(fechaNacimiento) {
//    // Obtener la fecha actual
//    var fechaActual = new Date();

//    // Calcular la fecha mínima permitida (hace al menos un año y un día)
//    var fechaMinima = new Date();
//    fechaMinima.setFullYear(fechaActual.getFullYear() - 1);
//    fechaMinima.setDate(fechaActual.getDate() - 1);

//    // Convertir la fecha de nacimiento proporcionada a un objeto Date
//    var fechaNacimientoObj = new Date(fechaNacimiento);

//    // Verificar si la fecha de nacimiento es mayor o igual a la fecha mínima
//    return fechaNacimientoObj <= fechaMinima;
//}

//function validateDateOfBirth(e, t) {
//    /*alert('hello');*/
//    try {
//        if (window.event) {
//            var charCode = window.event.keyCode;
//        } else if (e) {
//            var charCode = e.which;
//        } else {
//            return true;
//        }

//        // Permitir solo números, retroceso y caracteres barra (/)
//        if ((charCode > 47 && charCode < 58) || charCode === 8 || charCode === 47) {
//            return true;
//        } else {
//            return false;
//        }

//        // Validar que la fecha sea anterior a la fecha actual
//        var fechaNacimiento = document.getElementById("fechaNacimiento").value;
//        var fechaActual = new Date();
//        if (fechaNacimiento > fechaActual) {
//            return false;
//        } else {
//            return true;
//        }
//    } catch (err) {
//        alert(err.Description);
//    }
//}

//function mayor_edad() {
//	var edad = document.getElementById('FechaNacimiento').value;
//	if (edad < 1) {
//		// La edad es menor a un año
//		alert('edad menor');
//	}
//}

//function validarFechaNacimiento(e, t) {
//    try {
//        if (window.event) {
//            var charCode = window.event.keyCode;
//        } else if (e) {
//            var charCode = e.which;
//        } else {
//            return true;
//        }

//        // Permitir solo números, retroceso y caracteres barra (/)
//        if ((charCode > 47 && charCode < 58) || charCode === 8 || charCode === 47) {
//            return true;
//        } else {
//            return false;
//        }

//        // Validar que la fecha sea anterior a la fecha actual
//        var fechaNacimiento = document.getElementById("fechaNacimiento").value;
//        var fechaActual = new Date();
//        var fechaLimite = new Date(fechaActual.getFullYear() - 1);
//        if (fechaNacimiento > fechaLimite) {
//            alert("La fecha de nacimiento debe ser anterior al " + fechaLimite);
//            return false;
//        } else {
//            return true;
//        }
//    } catch (err) {
//        alert(err.Description);
//    }
//}


//const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;
//const CURRENT_YEAR = new Date().getFullYear();
//function validateDate(event) {
//    const birthDate = document.getElementById("fechaNacimiento").value;
//    const validationMessage = document.getElementById("validation-message");

//    if (!birthDate.match(DATE_REGEX)) {
//        validationMessage.classList.add("error");
//        validationMessage.innerHTML = "Fecha inválida. Formato: dd/mm/aaaa";
//        event.preventDefault();
//        return false;
//    }

//    const day = parseInt(birthDate.split("/")[0]);
//    const month = parseInt(birthDate.split("/")[1]);
//    const year = parseInt(birthDate.split("/")[2]);
//    const monthDays = new Date(year, month, 0).getDate();

//    if (day > monthDays) {
//        validationMessage.classList.add("error");
//        validationMessage.innerHTML = "Día inválido. Máximo permitido: " + monthDays;
//        event.preventDefault();
//        return false;
//    }

//    if (year > CURRENT_YEAR-1) {
//        validationMessage.classList.add("error");
//        validationMessage.innerHTML = "Año inválido. No puede ser mayor al actual: " + CURRENT_YEAR;
//        event.preventDefault();
//        return false;
//    }

//    validationMessage.classList.add("success");
//    validationMessage.innerHTML = "Fecha válida";
//    event.preventDefault();
//    document.getElementById("form").submit();
//    return true;
//}

//function validateDate(event) {
//    if (event.key === "Enter") {
//        const birthDate = document.getElementById("fechaNacimiento").value;
//        const validationMessage = document.getElementById("validation-message");

//        if (!birthDate.match(DATE_REGEX)) {
//            validationMessage.classList.add("error");
//            validationMessage.innerHTML = "Fecha inválida. Formato: dd/mm/aaaa";
//            return false; // Evita que se envíe el formulario
//        }

//        const day = parseInt(birthDate.split("/")[0]);
//        const month = parseInt(birthDate.split("/")[1]);
//        const year = parseInt(birthDate.split("/")[2]);
//        const monthDays = new Date(year, month, 0).getDate();

//        if (day > monthDays) {
//            validationMessage.classList.add("error");
//            validationMessage.innerHTML = "Día inválido. Máximo permitido: " + monthDays;
//            return false;
//        }

//        if (year > CURRENT_YEAR-1) {
//            validationMessage.classList.add("error");
//            validationMessage.innerHTML = "Año inválido. No puede ser mayor al actual: " + CURRENT_YEAR;
//            return false;
//        }

//        validationMessage.classList.add("success");
//        validationMessage.innerHTML = "Fecha válida";
//        return true; // Permite que se envíe el formulario
//    }
//}

//const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/;
//const CURRENT_YEAR = new Date().getFullYear();

//function validateDate(event) {
//    const birthDate = document.getElementById("fechaNacimiento").value;
//    const validationMessage = document.getElementById("validation-message");

//    if (!birthDate.match(DATE_REGEX)) {
//        validationMessage.classList.add("error");
//        validationMessage.innerHTML = "Fecha inválida. Formato: dd/mm/aaaa";
//        return false;
//    }

//    const day = parseInt(birthDate.split("/")[0]);
//    const month = parseInt(birthDate.split("/")[1]);
//    const year = parseInt(birthDate.split("/")[2]);
//    const monthDays = new Date(year, month, 0).getDate();

//    if (day > monthDays) {
//        validationMessage.classList.add("error");
//        validationMessage.innerHTML = "Día inválido. Máximo permitido: " + monthDays;
//        return false;
//    }

//    if (year > CURRENT_YEAR) {
//        validationMessage.classList.add("error");
//        validationMessage.innerHTML = "Año inválido. No puede ser mayor al actual: " + CURRENT_YEAR;
//        return false;
//    }

//    validationMessage.classList.add("success");
//    validationMessage.innerHTML = "Fecha válida";
//    return true;
//}

//function validateDate(event) {
//    // Obtén el valor del input
//    var inputDate = event.target.value;

//    // Verifica si se ingresó una fecha válida en formato dd/mm/yyyy
//    var isValidDate = /^(\d{2})\/(\d{2})\/(\d{4})$/.test(inputDate);

//    if (isValidDate) {
//        // Convierte la cadena de fecha en un objeto de fecha
//        var parts = inputDate.split("/");
//        var selectedDate = new Date(parts[2], parts[1] - 1, parts[0]);

//        // Calcula la fecha actual
//        var currentDate = new Date();

//        // Calcula la diferencia en milisegundos
//        var differenceInMilliseconds = currentDate - selectedDate;

//        // Calcula la diferencia en años
//        var differenceInYears = differenceInMilliseconds / (1000 * 60 * 60 * 24 * 365.25);

//        // Realiza la validación, permitiendo solo pacientes mayores de un año
//        if (differenceInYears < 1) {
//            alert("La fecha de nacimiento debe ser de pacientes mayores a un año.");
//            event.target.value = ""; // Limpia el valor del input
//        }
//    }
//    else {
//        alert("Por favor, ingresa una fecha válida en el formato dd/mm/yyyy.");
//        event.target.value = ""; // Limpia el valor del input
//    }
//}



