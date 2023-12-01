function onlyAlphabets(e, t) {
	try {
		if (window.event) {
			var charCode = window.event.keyCode;
		}
		else if (e) {
			var charCode = e.which;
		}
		else { return true; }
		if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
			return true;
		else
			return false;
	}
	catch (err) {
		alert(err.Description);
	}
}
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