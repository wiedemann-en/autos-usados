var Buscador = {
    iniciarBusqueda: function (jobId, fnCallbackProvider, fnCallbackFinish) {

        var conn = $.connection.busquedaProgressHub;

        $.connection.hub.starting(function () {
        });

        $.connection.hub.disconnected(function () {
            setTimeout(function () {
                $.connection.hub.start();
            }, 5000);
        });

        $.connection.hub.error(function (exception) {
            console.log(exception);
        });

        conn.client.progressChanged = function (message, progress) {
            fnCallbackProvider(message, progress);
        };

        conn.client.jobCompleted = function () {
            //Ejecutamos callback
            fnCallbackFinish();

            //Finalizamos la conexión
            $.connection.hub.stop();
        };

        conn.client.error = function (exception) {
        };

        // Start the connection.
        if ((jobId) && (jobId != undefined) && (jobId != null)) {
            $.connection.hub.start().done(function () {
                conn.server.trackJob(jobId);
            });
        }
    }
}