#!/bin/bash

confluent-hub install --no-prompt debezium/debezium-connector-postgresql:2.0.1
confluent-hub install --no-prompt debezium/debezium-connector-mysql:2.1.1
confluent-hub install --no-prompt confluentinc/kafka-connect-jdbc:10.7.0

echo "Launching Kafka Connect worker"
/etc/confluent/docker/run 

sleep infinity

