set -e

docker-compose -f docker-compose.yml build

docker-compose -f docker-compose.tests.yml build

docker-compose -f docker-compose.override.yml up --force-recreate -d

docker-compose -f docker-compose.tests.yml run boilerplate-api-integrationtests
docker-compose -f docker-compose.tests.yml run boilerplate-api-unittests

docker-compose -f docker-compose.override.yml stop