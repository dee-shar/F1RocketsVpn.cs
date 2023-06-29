#!/bin/bash

request_role="user"
timezone="Asia/Tokyo"
client_version="1.1.119"
api="https://api.f1rockets.com/app"
user_agent="Dart/2.19 (dart:io)"
application_code="f1rocket-googleplay-1"
device_code="$(cat /dev/urandom | tr -dc 'a-zA-Z0-9' | fold -w 16 | head -n 1)"

function check_app_version() {
	curl --request POST \
		--url "$api/version_check" \
		--user-agent "$user_agent" \
		--header "content-type: application/x-www-form-urlencoded" \
		--header "device-code: $device_code" \
		--header "timezone: $timezone" \
		--header "client-version: $client_version" \
		--header "app-code: $application_code" \
		--header "req-role: $request_role" \
		--data "{}"
}

function check_auth() {
	curl --request POST \
		--url "$api/auth_check" \
		--user-agent "$user_agent" \
		--header "content-type: application/x-www-form-urlencoded" \
		--header "device-code: $device_code" \
		--header "timezone: $timezone" \
		--header "client-version: $client_version" \
		--header "app-code: $application_code" \
		--header "req-role: $request_role" \
		--data "{}"
}

function get_base_info() {
	curl --request POST \
		--url "$api/base/get" \
		--user-agent "$user_agent" \
		--header "content-type: application/x-www-form-urlencoded" \
		--header "device-code: $device_code" \
		--header "timezone: $timezone" \
		--header "client-version: $client_version" \
		--header "app-code: $application_code" \
		--header "req-role: $request_role" \
		--data "{}"
}

function get_servers() {
	curl --request POST \
		--url "$api/node/list" \
		--user-agent "$user_agent" \
		--header "content-type: application/x-www-form-urlencoded" \
		--header "device-code: $device_code" \
		--header "timezone: $timezone" \
		--header "client-version: $client_version" \
		--header "app-code: $application_code" \
		--header "req-role: $request_role" \
		--data "{}"
}

function get_invite_history() {
	curl --request POST \
		--url "$api/get_invite_history" \
		--user-agent "$user_agent" \
		--header "content-type: application/x-www-form-urlencoded" \
		--header "device-code: $device_code" \
		--header "timezone: $timezone" \
		--header "client-version: $client_version" \
		--header "app-code: $application_code" \
		--header "req-role: $request_role" \
		--data "{}"
}
