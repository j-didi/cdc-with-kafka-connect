#!/bin/sh

add_connection() {

  while true; do

    sleep 5

    status=$(
      curl \
        -o /dev/null \
        -X POST \
        -H "Content-Type: application/json" \
        -w "%{http_code}\n" \
        --data "@/temp/$1" http://connect:8083/connectors
    )

    if [ "$status" = "201" ] || [ "$status" = "409" ]; then
      break
    fi

  done

  return 0
}

add_connection onboard-db-source.json
add_connection content-db-sink.json

sleep infinity
