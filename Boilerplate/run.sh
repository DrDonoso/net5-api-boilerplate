set -e
docker-compose -f docker-compose.yml -f docker-compose.override.yml build
docker-compose -f docker-compose.override.yml up --force-recreate -d