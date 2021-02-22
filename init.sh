output=$(echo $1 | xargs)

mv Boilerplate $output

find . -type f \( ! -name "init.sh" ! -path "*/\.git/*" \) -exec sed -i s/Boilerplate/$output/g {} +
find . -type f \( ! -name "init.sh" ! -path "*/\.git/*" \) -exec sed -i s/boilerplate/$(echo ${output,,})/g {} +
find . -type f \( ! -name "init.sh" ! -path "*/\.git/*" \) -exec sed -i s/BOILERPLATE/$(echo ${output^^})/g {} +

for j in $(find . -type d -name *Boilerplate*)
do
    mv $j ${j/Boilerplate/$output}
done

for j in $(find . -type f -name *Boilerplate*)
do
    mv $j ${j/Boilerplate/$output}
done

rm -rf $output/*.sln && dotnet new sln -o $output && dotnet sln $output add **/**/**/*.csproj