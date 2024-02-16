#!/bin/bash

echo " " &&
echo "----------------" &&
echo "Construyendo imagen" &&
echo "----------------" &&
echo " " &&

docker build -t api-aspdotnet . &&

echo " " &&
echo "----------------" &&
echo "Añadiendo Tag" &&
echo "----------------" &&
echo " " &&

docker tag api-aspdotnet laut4/api-aspdotnet:csharp &&


echo " " &&
echo "----------------" &&
echo "Subiendo la Imagen" &&
echo "----------------" &&
echo " " &&


docker push laut4/api-aspdotnet:csharp 

