#!/bin/bash
# Elimina la base de datos antigua si existe
rm -f /app/works.db
# Copia la nueva base de datos
cp /src/final-proyect/works.db /app/
# Ejecuta la aplicaci�n
dotnet final-proyect.dll
