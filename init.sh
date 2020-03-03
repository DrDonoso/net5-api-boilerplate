mv Boilerplate $1

find . -type f \( ! -name "init.sh" \) -exec sed -i s/Boilerplate/$1/g {} +
find . -type f \( ! -name "init.sh" \) -exec sed -i s/boilerplate/${1,,}/g {} +
find . -type f \( ! -name "init.sh" \) -exec sed -i s/BOILERPLATE/$(echo ${1^^} | tr . _)/g {} +

for j in $(find . -type d -name *Boilerplate*)
do
    mv $j ${j/Boilerplate/$1}
done

for j in $(find . -type f -name *Boilerplate*)
do
    mv $j ${j/Boilerplate/$1}
done

rm -rf $1/*.sln && dotnet new sln -o $1 && dotnet sln $1 add **/**/**/*.csproj