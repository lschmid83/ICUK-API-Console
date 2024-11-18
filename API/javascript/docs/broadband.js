[
{
    "name": "broadband_order_update_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broaband orders which have been updated within a date range.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_information'>broadband_order_information[]</a>",
            "field": "order_updates",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_order_information structs."
        }
        ]
    }
},
{
    "name": "broadband_address",
    "group": "Type",
    "user_type": 4,
    "description": "Represents an address.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "sub_premises",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the subpremises."
        },
        {
            "type": "String",
            "field": "premises_name",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the premises."
        },
        {
            "type": "String",
            "field": "thoroughfare_number",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Number of the thouroughfare."
        },
        {
            "type": "String",
            "field": "thoroughfare_name",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the thoroughfare."
        },
        {
            "type": "String",
            "field": "locality",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Locality of the address."
        },
        {
            "type": "String",
            "field": "post_town",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the post town."
        },
        {
            "type": "String",
            "field": "postcode",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Postcode of the address."
        },
        {
            "type": "String",
            "field": "district_id",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "ID of the district."
        }
        ]
    }
},
{
    "name": "broadband_address_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents address search results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_address'>broadband_address[]</a>",
            "field": "addresses",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_address structs."
        }
        ]
    }
},
{
    "name": "broadband_authentication_log_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband authentication log results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_authentication_log'>broadband_authentication_log[]</a>",
            "field": "authentication_logs",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_authentication_log structs."
        }
        ]
    }
},
{
    "name": "broadband_availability_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband availability results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_exchange_info'>broadband_exchange_info</a>",
            "field": "exchange",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadband exchange information."
        },
        {
            "type": "<a href='#api-Type-broadband_availability'>broadband_availability[]</a>",
            "field": "products",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_availability structs."
        }
        ]
    }
},
{
    "name": "broadband_availability",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband availability.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "Decimal",
            "field": "likely_down_speed",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Likely down speed of the product."
        },
        {
            "type": "Decimal",
            "field": "likely_up_speed",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Likely up speed of the product."
        },
        {
            "type": "Bool",
            "field": "availability",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Availability of the product."
        },
        {
            "type": "DateTime",
            "field": "availability_date",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Availability date."
        }
        ]
    }
},
{
    "name": "broadband_order_cease",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a cease broadband order request.",
    "property": {
        "fields": [
        {
            "type": "DateTime",
            "field": "request_date",
            "optional": false,
            "day": 5,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Cease request date."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_daily",
    "group": "Type",
    "user_type": 4,
    "description": "Represents daily broadband data transfer usage.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_daily_details'>broadband_data_transfer_daily_details</a>",
            "field": "off_peak",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Off peak data transfer."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_daily_details'>broadband_data_transfer_daily_details</a>",
            "field": "peak",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak data transfer."
        },
        {
            "type": "Integer",
            "field": "day",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Day."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_daily_details",
    "group": "Type",
    "user_type": 4,
    "description": "Represents daily broadband data transfer usage details.",
    "property": {
        "fields": [
        {
            "type": "Long",
            "field": "download",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Download."
        },
        {
            "type": "Long",
            "field": "upload",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Upload."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_daily_result",
    "group": "Type",
    "user_type": 4,
    "description": "Represents daily broadband data transfer usage results for a month.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of user."
        },
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Month."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_peak_hours'>broadband_data_transfer_peak_hours</a>",
            "field": "peak_hours",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak hours."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_daily'>broadband_data_transfer_daily</a>",
            "field": "days",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_data_transfer_daily structs."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_monthly_download",
    "group": "Type",
    "user_type": 4,
    "description": "Represents monthly broadband data transfer download usage for a user.",
    "property": {
        "fields": [
        {
            "type": "Long",
            "field": "quota",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Quota."
        },
        {
            "type": "Long",
            "field": "usage",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Usage."
        },
        {
            "type": "Long",
            "field": "overuse",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Overuse."
        },
        {
            "type": "Long",
            "field": "projected",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Projected."
        },
        {
            "type": "Long",
            "field": "projected_overuse",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Projected overuse."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_monthly_details",
    "group": "Type",
    "user_type": 4,
    "description": "Represents monthly broadband data transfer usage details.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_download'>broadband_data_transfer_monthly_download</a>",
            "field": "download",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Download usage."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_upload'>broadband_data_transfer_monthly_upload</a>",
            "field": "upload",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Upload usage."
        },
        {
            "type": "Decimal",
            "field": "overuse_charge",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Overuse charge (£)."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_hourly",
    "group": "Type",
    "user_type": 4,
    "description": "Represents hourly broadband data transfer usage.",
    "property": {
        "fields": [
        {
            "type": "Long",
            "field": "download",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Download."
        },
        {
            "type": "Long",
            "field": "upload",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Upload."
        },
        {
            "type": "Integer",
            "field": "hour",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Hour number."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_hourly_result",
    "group": "Type",
    "user_type": 4,
    "description": "Represents hourly broadband data transfer usage results.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of user."
        },
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Month."
        },
        {
            "type": "Integer",
            "field": "day",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Day."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_hourly'>broadband_data_transfer_hourly[]</a>",
            "field": "hours",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_data_transfer_hourly structs."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_peak_hours",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband data transfer peak hours.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "start",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Start time."
        },
        {
            "type": "String",
            "field": "end",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "End time."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_monthly_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents monthly broadband data transfer usage results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_result'>broadband_data_transfer_monthly_result[]</a>",
            "field": "data_transfers",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_data_transfer_monthly_result structs."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_monthly_upload",
    "group": "Type",
    "user_type": 4,
    "description": "Represents monthly broadband data transfer upload usage for a user.",
    "property": {
        "fields": [
        {
            "type": "Long",
            "field": "usage",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Usage."
        },
        {
            "type": "Long",
            "field": "projected",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Projected."
        }
        ]
    }
},
{
    "name": "broadband_exchange_info",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband exchange information.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "status",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Status of the exchange."
        },
        {
            "type": "String",
            "field": "message",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Exchange message."
        },
        {
            "type": "String",
            "field": "exchange_code",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Exchange code."
        },
        {
            "type": "String",
            "field": "exchange_name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the exchange."
        }
        ]
    }
},
{
    "name": "broadband_authentication_log",
    "group": "Type",
    "user_type": 4,
    "description": "Represents the authentication logs of the broadband user.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the user."
        },
        {
            "type": "Bool",
            "field": "reply",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Represents whether the user was authenticated or not."
        },
        {
            "type": "String",
            "field": "additional_details",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Additional details. E.g. Login was from another line."
        },
        {
            "type": "DateTime",
            "field": "time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Date and time of the authentication attempt."
        }
        ]
    }
},
{
    "name": "broadband_ipv4",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband IPv4 address.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "ip",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP address."
        },
        {
            "type": "String",
            "field": "network",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Network address."
        },
        {
            "type": "String",
            "field": "netmask",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Netmask."
        },
        {
            "type": "Integer",
            "field": "range",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Number of IP addresses in subnet."
        },
        {
            "type": "String[]",
            "field": "usable",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Usable IP addresses."
        },
        {
            "type": "String",
            "field": "broadcast",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadcast address."
        }
        ]
    }
},
{
    "name": "broadband_ipv6",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband IPv6 address.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "ip",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP address."
        },
        {
            "type": "String",
            "field": "network",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Network address."
        },
        {
            "type": "String",
            "field": "netmask",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Netmask."
        },
        {
            "type": "Long",
            "field": "range",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Number of IP addresses in subnet."
        },
        {
            "type": "String",
            "field": "broadcast",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadcast address."
        }
        ]
    }
},
{
    "name": "broadband_ip_deallocation",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband IP dealloaction.",
    "property": {
        "fields": [
        {
            "type": "Integer",
            "field": "prefix",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP prefix."
        },
        {
            "type": "String",
            "field": "ip",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP address."
        }
        ]
    }
},
{
    "name": "broadband_ip_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents IP address assignements for a broadband connection.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "ip",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP address."
        },
        {
            "type": "String",
            "field": "allocation",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Type of allocation."
        },
        {
            "type": "<a href='#api-Type-broadband_ipv4'>broadband_ipv4[]</a>",
            "field": "routed",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_ipv4 structs."
        },
        {
            "type": "<a href='#api-Type-broadband_ipv6'>broadband_ipv6</a>",
            "field": "ipv6",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "broadband_ipv6 struct."
        }
        ]
    }
},
{
    "name": "broadband_online_status",
    "group": "Type",
    "user_type": 4,
    "description": "Represents the online status of broadband user.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Username."
        },
        {
            "type": "DateTime",
            "field": "login_time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Date and time of last login."
        },
        {
            "type": "String",
            "field": "time_online",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Time online."
        },
        {
            "type": "Bool",
            "field": "is_online",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Is online."
        }
        ]
    }
},
{
    "name": "broadband_online_status_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broaband online status results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_online_status'>broadband_online_status[]</a>",
            "field": "online_statuses",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_online_status structs."
        }
        ]
    }
},
{
    "name": "broadband_online_status_termination",
    "group": "Type",
    "user_type": 4,
    "description": "Represents the session termination response.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "message",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Response Message."
        },
        {
            "type": "Bool",
            "field": "is_success_response",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Determines whether the session termination was successful or not."
        }
        ]
    }
},
{
    "name": "broadband_order_details",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband order details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the user."
        },
        {
            "type": "String",
            "field": "password",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Password of the user."
        },
        {
            "type": "Bool",
            "field": "simultaneous_provide",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Simultaneous provide."
        },
        {
            "type": "String",
            "field": "bt_order_reference",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "BT order reference."
        },
        {
            "type": "Integer",
            "field": "product_id",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "ID of the product."
        },
        {
            "type": "DateTime",
            "field": "activation_date",
            "optional": true,
            "day": 5,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Activation date."
        },
        {
            "type": "String",
            "field": "mac_code",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "MAC Code."
        },
        {
            "type": "String",
            "field": "losing_isp",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Losing ISP."
        },
        {
            "type": "Bool",
            "field": "fast_track",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Fast track order."
        },
        {
            "type": "<a href='#api-Enum-broadband_care_level'>broadband_care_level</a>",
            "field": "care_level",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Care level."
        },
        {
            "type": "Bool",
            "field": "send_completion_email",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Send completion email."
        },
        {
            "type": "<a href='#api-Type-broadband_order_ip'>broadband_order_ip</a>",
            "field": "ip",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP allocation details."
        },
        {
            "type": "<a href='#api-Type-broadband_order_ripe'>broadband_order_ripe</a>",
            "field": "ripe",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE contact details."
        },
        {
            "type": "<a href='#api-Type-broadband_order_installation_options'>broadband_order_installation_options</a>",
            "field": "installation_options",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Installation options."
        }
        ]
    }
},
{
    "name": "broadband_order_contact",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband order customer contact details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "contact_number",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Contact number (CLI)."
        },
        {
            "type": "String",
            "field": "contact_mobile",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Mobile number."
        },
        {
            "type": "String",
            "field": "email_address",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Email address of the user."
        }
        ]
    }
},
{
    "name": "broadband_order",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband order.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_details'>broadband_order_details</a>",
            "field": "order",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadband order details."
        },
        {
            "type": "<a href='#api-Type-broadband_order_customer'>broadband_order_customer</a>",
            "field": "customer",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadband customer details."
        }
        ]
    }
},
{
    "name": "broadband_order_customer",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband order customer details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "forename",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Forename of the customer."
        },
        {
            "type": "String",
            "field": "surname",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Surname of the customer."
        },
        {
            "type": "<a href='#api-Type-broadband_order_address'>broadband_order_address</a>",
            "field": "address",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Customer address."
        },
        {
            "type": "<a href='#api-Type-broadband_order_contact'>broadband_order_contact</a>",
            "field": "contact",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Customer contact details."
        }
        ]
    }
},
{
    "name": "broadband_order_event",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband order events.",
    "property": {
        "fields": [
        {
            "type": "DateTime",
            "field": "date",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Event date."
        },
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of event."
        },
        {
            "type": "String",
            "field": "description",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Description of event."
        }
        ]
    }
},
{
    "name": "broadband_order_history",
    "group": "Type",
    "user_type": 4,
    "description": "Represents events which occured in the broadband order history.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_event'>broadband_order_event[]</a>",
            "field": "order_events",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_order_event structs."
        }
        ]
    }
},
{
    "name": "broadband_order_information",
    "group": "Type",
    "user_type": 4,
    "description": "Represents detailed broadband order information.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_summary'>broadband_order_summary</a>",
            "field": "order_summary",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order summary."
        },
        {
            "type": "<a href='#api-Type-broadband_user'>broadband_user</a>",
            "field": "broadband_user",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadband customer details."
        },
        {
            "type": "<a href='#api-Type-broadband_order_history'>broadband_order_history</a>",
            "field": "order_history",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order history."
        }
        ]
    }
},
{
    "name": "broadband_order_installation_options",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband order installation options for FTTC and FTTP connections.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Enum-broadband_appointment_type'>broadband_appointment_type</a>",
            "field": "engineer_appointment",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Appointment time either morning or evening."
        },
        {
            "type": "String",
            "field": "site_visit_note",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Site visit note (Maximum 75 characters)."
        },
        {
            "type": "String",
            "field": "special_arrangement_note",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Special arrangement note (Maximum 40 characters)."
        },
        {
            "type": "String",
            "field": "hazard_note",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Hazard note (Maximum 40 characters)."
        },
        {
            "type": "String",
            "field": "password",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Appointment password (Maximum 20 characters)."
        }
        ]
    }
},
{
    "name": "broadband_order_ip",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband order IP allocation details.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Enum-broadband_ip'>broadband_ip</a>",
            "field": "allocation",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Type of allocation."
        },
        {
            "type": "Integer",
            "field": "prefix",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP prefix."
        },
        {
            "type": "Bool",
            "field": "ipv6",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Allocate IPv6 address."
        }
        ]
    }
},
{
    "name": "broadband_order_ripe",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband order RIPE contact details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "ripe_admin_nic_handle",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE admin nic-handle."
        },
        {
            "type": "String",
            "field": "ripe_tech_nic_handle",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE tech nic-handle. (Admin nic-handle will be used if left blank)"
        },
        {
            "type": "String",
            "field": "ripe_justification",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE justification."
        }
        ]
    }
},
{
    "name": "broadband_order_summary",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a summary of broadband orders.",
    "property": {
        "fields": [
        {
            "type": "Integer",
            "field": "order_id",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order ID."
        },
        {
            "type": "String",
            "field": "reference",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Client reference."
        },
        {
            "type": "Integer",
            "field": "product_id",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Product ID."
        },
        {
            "type": "String",
            "field": "technology",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Technology."
        },
        {
            "type": "String",
            "field": "cli",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Calling line identity."
        },
        {
            "type": "String",
            "field": "mac_code",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "MAC Code."
        },
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the user."
        },
        {
            "type": "<a href='#api-Enum-broadband_order_type'>broadband_order_type</a>",
            "field": "order_type",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order type."
        },
        {
            "type": "<a href='#api-Enum-broadband_order_subtype'>broadband_order_subtype</a>",
            "field": "order_subtype",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order subtype."
        },
        {
            "type": "String",
            "field": "order_status",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order status."
        },
        {
            "type": "DateTime",
            "field": "order_date",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Order date."
        },
        {
            "type": "DateTime",
            "field": "required_date",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Required date."
        },
        {
            "type": "DateTime",
            "field": "last_update",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Last update."
        }
        ]
    }
},
{
    "name": "broadband_order_summary_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband order summary results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_summary'>broadband_order_summary[]</a>",
            "field": "broadband_orders",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_order_summary structs."
        }
        ]
    }
},
{
    "name": "broadband_product_assured_rate",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband assured rate product details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price."
        }
        ]
    }
},
{
    "name": "broadband_product_care",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband care product details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price."
        },
        {
            "type": "Integer",
            "field": "care_level",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Care level."
        }
        ]
    }
},
{
    "name": "broadband_product_elevated_best_effort",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband elevated best effort product details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price."
        }
        ]
    }
},
{
    "name": "broadband_product",
    "group": "Type",
    "user_type": 4,
    "description": "Represents ADSL broadband product details.",
    "property": {
        "fields": [
        {
            "type": "Integer",
            "field": "id",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "ID of the product."
        },
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price (£)."
        },
        {
            "type": "Decimal",
            "field": "activation_fee",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Activation fee (£)."
        },
        {
            "type": "Decimal",
            "field": "adsl_migration_fee",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "ADSL Migration fee (£)."
        },
        {
            "type": "Decimal",
            "field": "adsl_llu_migration_fee",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "ADSL LLU Migration fee (£)."
        },
        {
            "type": "Decimal",
            "field": "fttc_migration_fee",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "FTTC Migration fee (£)."
        },
        {
            "type": "Decimal",
            "field": "fttc_llu_migration_fee",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "FTTC LLU Migration fee (£)."
        },
        {
            "type": "Decimal",
            "field": "fttc_reverse_migration_fee",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "FTTC Reverse Migration fee (£)."
        },
        {
            "type": "Decimal",
            "field": "fast_track_price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Fast-track price (£)."
        },
        {
            "type": "<a href='#api-Enum-broadband_product_provider'>broadband_product_provider</a>",
            "field": "provider",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Provider."
        },
        {
            "type": "String",
            "field": "technology",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Technology."
        },
        {
            "type": "Integer",
            "field": "down_speed",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Down speed (kbps)."
        },
        {
            "type": "Integer",
            "field": "up_speed",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Up speed (kbps)."
        },
        {
            "type": "Integer",
            "field": "peak_cap",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak cap (GB)."
        },
        {
            "type": "Integer",
            "field": "off_peak_cap",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Off peak cap (GB)."
        },
        {
            "type": "Integer",
            "field": "contention",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Contention."
        },
        {
            "type": "<a href='#api-Enum-broadband_product_class'>broadband_product_class</a>",
            "field": "product_class",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Product class."
        },
        {
            "type": "Integer",
            "field": "provide_lead_time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Provide lead time (days)."
        },
        {
            "type": "Integer",
            "field": "migration_lead_time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Migration lead time (days)."
        },
        {
            "type": "String",
            "field": "peak_start",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak start (hh:mm:ss)."
        },
        {
            "type": "String",
            "field": "peak_end",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak end (hh:mm:ss)."
        },
        {
            "type": "Integer",
            "field": "contract_length",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Contract length (months)."
        },
        {
            "type": "Integer",
            "field": "cease_lead_time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Cease lead time (days)."
        },
        {
            "type": "DateTime",
            "field": "cease_first_date",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "First acceptable cease date."
        },
        {
            "type": "Bool",
            "field": "requires_our_line_rental",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Requires out line rental."
        },
        {
            "type": "Bool",
            "field": "unlimited_cap",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Unlimited cap."
        }
        ]
    }
},
{
    "name": "broadband_product_ip",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband IP product details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price."
        }
        ]
    }
},
{
    "name": "broadband_product_other",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband other products details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price."
        }
        ]
    }
},
{
    "name": "broadband_product_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband product results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_product_ip'>broadband_product_ip[]</a>",
            "field": "ip",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product_ip structs."
        },
        {
            "type": "<a href='#api-Type-broadband_product_routed'>broadband_product_routed[]</a>",
            "field": "routed",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product_routed structs."
        },
        {
            "type": "<a href='#api-Type-broadband_product_elevated_best_effort'>broadband_product_elevated_best_effort[]</a>",
            "field": "elevated_best_effort",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product_elevated_best_effort structs."
        },
        {
            "type": "<a href='#api-Type-broadband_product_care'>broadband_product_care[]</a>",
            "field": "care",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product_care structs."
        },
        {
            "type": "<a href='#api-Type-broadband_product_assured_rate'>broadband_product_assured_rate[]</a>",
            "field": "assured_rate",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product_assured_rate structs."
        },
        {
            "type": "<a href='#api-Type-broadband_product'>broadband_product[]</a>",
            "field": "broadband_product",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product structs."
        },
        {
            "type": "<a href='#api-Type-broadband_product_other'>broadband_product_other[]</a>",
            "field": "other_products",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_product_other structs."
        }
        ]
    }
},
{
    "name": "broadband_product_routed",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband routed product details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the product."
        },
        {
            "type": "String",
            "field": "category",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Category."
        },
        {
            "type": "Decimal",
            "field": "price",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Price."
        },
        {
            "type": "Integer",
            "field": "prefix",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "ID of the product."
        }
        ]
    }
},
{
    "name": "broadband_product_user",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband product order user details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the usr."
        },
        {
            "type": "String",
            "field": "password",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Password of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_order_address'>broadband_order_address</a>",
            "field": "user_address",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Installation address."
        }
        ]
    }
},
{
    "name": "broadband_ripe_person",
    "group": "Type",
    "user_type": 4,
    "description": "Represents RIPE person contact details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the contact."
        },
        {
            "type": "String",
            "field": "nic_handle",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": true,
            "description": "Unique identifier that references RIPE Database objects containing contact details for a specific person or role."
        },
        {
            "type": "String",
            "field": "mnt_by",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": true,
            "description": "Identifier of the maintainer that is authorised to perform updates on an object."
        },
        {
            "type": "String",
            "field": "address_line_1",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "First line of address."
        },
        {
            "type": "String",
            "field": "address_line_2",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Second line of address."
        },
        {
            "type": "String",
            "field": "town",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of town."
        },
        {
            "type": "String",
            "field": "county",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of county."
        },
        {
            "type": "String",
            "field": "postcode",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Postcode of the address."
        },
        {
            "type": "String",
            "field": "phone_number",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Phone number of contact."
        }
        ]
    }
},
{
    "name": "broadband_ripe_person_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents RIPE person results assigned to a reseller account.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_ripe_person'>broadband_ripe_person[]</a>",
            "field": "ripe_persons",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_ripe_person structs."
        }
        ]
    }
},
{
    "name": "broadband_ip_allocation",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband IP allocation.",
    "property": {
        "fields": [
        {
            "type": "Integer",
            "field": "prefix",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "IP prefix."
        },
        {
            "type": "String",
            "field": "ripe_admin_nic_handle",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE admin nic-handle."
        },
        {
            "type": "String",
            "field": "ripe_tech_nic_handle",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE tech nic-handle. (Admin NIC handle will be used if left blank)"
        },
        {
            "type": "String",
            "field": "ripe_justification",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "RIPE justification."
        }
        ]
    }
},
{
    "name": "broadband_session_history",
    "group": "Type",
    "user_type": 4,
    "description": "Represents the session history of the broadband user.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the user."
        },
        {
            "type": "String",
            "field": "framed_ip",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Framed IP."
        },
        {
            "type": "DateTime",
            "field": "start_time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Time the session started."
        },
        {
            "type": "DateTime",
            "field": "stop_time",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Time the session ended."
        },
        {
            "type": "String",
            "field": "time_online",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Duration of the session."
        },
        {
            "type": "Long",
            "field": "data_in",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Amount of data that the user sent during the session."
        },
        {
            "type": "Long",
            "field": "data_out",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Amount of data that the user received during the session."
        },
        {
            "type": "String",
            "field": "termination_cause",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Cause of the session termination."
        }
        ]
    }
},
{
    "name": "broadband_session_history_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broadband session history results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_session_history'>broadband_session_history[]</a>",
            "field": "session_history",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_session_history structs."
        }
        ]
    }
},
{
    "name": "broadband_user",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband user.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of the user."
        },
        {
            "type": "String",
            "field": "password",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Password of the user."
        },
        {
            "type": "String",
            "field": "cli",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Calling line identity."
        },
        {
            "type": "String",
            "field": "product",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Broadband product the user subscribes to."
        },
        {
            "type": "String",
            "field": "forename",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Forename of the user."
        },
        {
            "type": "String",
            "field": "surname",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Surname of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_order_address'>broadband_order_address</a>",
            "field": "installation_address",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Installation address."
        },
        {
            "type": "Bool",
            "field": "is_online",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Online status."
        }
        ]
    }
},
{
    "name": "broadband_order_address",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broadband order customer installation address.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "house_name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "House name."
        },
        {
            "type": "String",
            "field": "street_name",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Street name."
        },
        {
            "type": "String",
            "field": "town",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Town."
        },
        {
            "type": "String",
            "field": "county",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "County."
        },
        {
            "type": "String",
            "field": "postcode",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Postcode."
        }
        ]
    }
},
{
    "name": "broadband_user_contact",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broaband user account contact details.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "forename",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Forename of the user."
        },
        {
            "type": "String",
            "field": "surname",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Surname of the user."
        },
        {
            "type": "String",
            "field": "phone",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Phone of the user."
        },
        {
            "type": "String",
            "field": "email",
            "optional": true,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Email address of the user."
        }
        ]
    }
},
{
    "name": "broadband_user_password",
    "group": "Type",
    "user_type": 4,
    "description": "Represents a broaband user password.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "password",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Password of the user."
        }
        ]
    }
},
{
    "name": "broadband_data_transfer_monthly_result",
    "group": "Type",
    "user_type": 4,
    "description": "Represents monthly summary of broadband data transfer usage results.",
    "property": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Name of user."
        },
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Month."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_peak_hours'>broadband_data_transfer_peak_hours</a>",
            "field": "peak_hours",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak hours."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_details'>broadband_data_transfer_monthly_details</a>",
            "field": "off_peak",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Off peak data transfer."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_details'>broadband_data_transfer_monthly_details</a>",
            "field": "peak",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Peak data transfer."
        },
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_details'>broadband_data_transfer_monthly_details</a>",
            "field": "total",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Total data transfer."
        }
        ]
    }
},
{
    "name": "broadband_user_results",
    "group": "Type",
    "user_type": 4,
    "description": "Represents broaband user results.",
    "property": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_user'>broadband_user[]</a>",
            "field": "broadband_users",
            "optional": false,
            "day": 0,
            "time": false,
            "date": true,
            "read_only": false,
            "description": "Array of broadband_user structs."
        }
        ]
    }
},
{
    "name": "broadband_appointment_type",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents broadband engineer apointment types.",
    "member": {
        "fields": [
        {
            "field": "NONE",
            "value": 0,
            "description": "None",
            "summary": "None."
        },
        {
            "field": "AM",
            "value": 1,
            "description": "Morning",
            "summary": "Morning."
        },
        {
            "field": "PM",
            "value": 2,
            "description": "Afternoon",
            "summary": "Afternoon."
        }
        ]
    }
},
{
    "name": "broadband_ip",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents broadband IP allocation types.",
    "member": {
        "fields": [
        {
            "field": "DYNAMIC",
            "value": 0,
            "description": "Dynamic",
            "summary": "Dynamic."
        },
        {
            "field": "STATIC",
            "value": 1,
            "description": "Static",
            "summary": "Static."
        },
        {
            "field": "STATIC_ROUTED",
            "value": 2,
            "description": "Static + Routed",
            "summary": "Static + Routed."
        }
        ]
    }
},
{
    "name": "broadband_order_status",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents the order status of a broadband order.",
    "member": {
        "fields": [
        {
            "field": "RECEIVED",
            "value": 1,
            "description": "Received",
            "summary": "Received."
        },
        {
            "field": "PROCESSING",
            "value": 2,
            "description": "Processing",
            "summary": "Processing."
        },
        {
            "field": "COMMITTED",
            "value": 3,
            "description": "Committed",
            "summary": "Committed."
        },
        {
            "field": "DELAYED",
            "value": 4,
            "description": "Delayed",
            "summary": "Delayed."
        },
        {
            "field": "COMPLETE",
            "value": 5,
            "description": "Complete",
            "summary": "Complete."
        },
        {
            "field": "REJECTED",
            "value": 6,
            "description": "Rejected",
            "summary": "Rejected."
        },
        {
            "field": "CANCELLED",
            "value": 7,
            "description": "Cancelled",
            "summary": "Cancelled."
        },
        {
            "field": "ALL",
            "value": 100,
            "description": "All",
            "summary": "All."
        }
        ]
    }
},
{
    "name": "broadband_order_subtype",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents the different subtypes of broadband order.",
    "member": {
        "fields": [
        {
            "field": "PROVIDE_DIRECTORY_NUMBER",
            "value": 1,
            "description": "Provide directory number",
            "summary": "Provide directory number."
        },
        {
            "field": "PROVIDE_ADDRESS",
            "value": 2,
            "description": "Provide address",
            "summary": "Provide address."
        },
        {
            "field": "MIGRATE_DIRECTORY_NUMBER",
            "value": 3,
            "description": "Migrate directory number",
            "summary": "Migrate directory number."
        },
        {
            "field": "MIGRATE_ADDRESS",
            "value": 4,
            "description": "Migrate address",
            "summary": "Migrate address."
        },
        {
            "field": "MIGRATE_FAMILY",
            "value": 5,
            "description": "Migrate family",
            "summary": "Migrate family."
        },
        {
            "field": "COPPER_TO_FIBRE",
            "value": 6,
            "description": "Copper to fibre",
            "summary": "Copper to fibre."
        },
        {
            "field": "FIBRE_TO_COPPER",
            "value": 7,
            "description": "Fibre to copper",
            "summary": "Fibre to copper."
        },
        {
            "field": "SIM_PROVIDE",
            "value": 8,
            "description": "Sim provide",
            "summary": "Sim provide."
        },
        {
            "field": "HOME_MOVE",
            "value": 9,
            "description": "Home move",
            "summary": "Home move."
        },
        {
            "field": "MODIFY_TRAFFIC_WEIGHTING",
            "value": 10,
            "description": "Modify traffic weighting",
            "summary": "Modify traffic weighting."
        },
        {
            "field": "MODIFY_ADVANCED_SERVICES",
            "value": 11,
            "description": "Modify advanced services",
            "summary": "Modify advanced services."
        },
        {
            "field": "MODIFY_SPEED",
            "value": 12,
            "description": "Modify speed",
            "summary": "Modify speed."
        },
        {
            "field": "MODIFY_CARE",
            "value": 13,
            "description": "Modify care",
            "summary": "Modify care."
        },
        {
            "field": "MODIFY_STABILITY",
            "value": 14,
            "description": "Modify stability",
            "summary": "Modify stability."
        },
        {
            "field": "MODIFY_MODIFIED_FAULT_THRESHOLD",
            "value": 15,
            "description": "Modify modified fault threshold",
            "summary": "Modify modified fault threshold."
        },
        {
            "field": "MODIFY_INTERLEAVING",
            "value": 16,
            "description": "Modify interleaving",
            "summary": "Modify interleaving."
        },
        {
            "field": "CEASE",
            "value": 17,
            "description": "Cease",
            "summary": "Cease."
        },
        {
            "field": "MIGRATE_AWAY",
            "value": 18,
            "description": "Migrate away",
            "summary": "Migrate away."
        },
        {
            "field": "OTHER",
            "value": 19,
            "description": "Unknown",
            "summary": "Unknown."
        }
        ]
    }
},
{
    "name": "broadband_order_type",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents the different types of broadband order.",
    "member": {
        "fields": [
        {
            "field": "PROVIDE",
            "value": 1,
            "description": "Provide",
            "summary": "Provide."
        },
        {
            "field": "MIGRATE",
            "value": 2,
            "description": "Migrate",
            "summary": "Migrate."
        },
        {
            "field": "MODIFY",
            "value": 3,
            "description": "Modify",
            "summary": "Modify."
        },
        {
            "field": "CEASE",
            "value": 4,
            "description": "Cease",
            "summary": "Cease."
        },
        {
            "field": "ALL",
            "value": 100,
            "description": "All",
            "summary": "All."
        }
        ]
    }
},
{
    "name": "broadband_product_class",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents broadband ADSL product class.",
    "member": {
        "fields": [
        {
            "field": "HOME",
            "value": 1,
            "description": "Home",
            "summary": "Home."
        },
        {
            "field": "BUSINESS",
            "value": 2,
            "description": "Business",
            "summary": "Business."
        },
        {
            "field": "ENTERPRISE",
            "value": 3,
            "description": "Enterprise",
            "summary": "Enterprise."
        }
        ]
    }
},
{
    "name": "broadband_product_provider",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents broadband ADSL product provider.",
    "member": {
        "fields": [
        {
            "field": "WBC_21CN",
            "value": 1,
            "description": "WBC 21CN",
            "summary": "WBC 21CN."
        },
        {
            "field": "WBC_20CN",
            "value": 3,
            "description": "WBC 20CN",
            "summary": "WBC 20CN."
        },
        {
            "field": "CABLE_AND_WIRELESS",
            "value": 4,
            "description": "Cable & Wireless",
            "summary": "Cable & Wireless."
        }
        ]
    }
},
{
    "name": "broadband_care_level",
    "group": "Enum",
    "user_type": 4,
    "description": "Represents broadband ADSL product care level.",
    "member": {
        "fields": [
        {
            "field": "STANDARD",
            "value": 1,
            "description": "Standard",
            "summary": "Standard."
        },
        {
            "field": "ENHANCED",
            "value": 2,
            "description": "Enhanced",
            "summary": "Enhanced."
        }
        ]
    }
},
{
    "name": "Gets broadband address",
    "type": "GET",
    "url": "/broadband/address_search/{postcode}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Address",
    "controller_name": "BroadbandAddressController",
    "controller": "Methods for searching for addresses.",
    "description": "Search for your postcode and it will return a list of BT adddress search results.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "postcode",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Postcode of address."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_address'>broadband_address[]</a>",
            "field": "addresses",
            "optional": false,
            "description": "Array of broadband_address structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"addresses\": [\n        {\n            \"sub_premises\": \"\",\n            \"premises_name\": \"\",\n            \"thoroughfare_number\": \"\",\n            \"thoroughfare_name\": \"\",\n            \"locality\": \"\",\n            \"post_town\": \"\",\n            \"post_code\": \"\",\n            \"district_id\": \"\",\n        } \n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband authentication attempts",
    "type": "GET",
    "url": "/broadband/authentication_logs/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Authentication",
    "controller_name": "BroadbandAuthenticationController",
    "controller": " Methods for retrieving the authentication logs of broadband users.",
    "description": "Retrieves the past 50 authentication attempts for a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_authentication_log'>broadband_authentication_log[]</a>",
            "field": "authentication_logs",
            "optional": false,
            "description": "Array of broadband_authentication_log structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"authentication_logs\": [\n        {\n            \"username\": \"user@realm.co.uk\",\n            \"reply\": true,\n            \"additional_details\": \"Accept\",\n            \"time\": \"2014-00-01T08:00:00\"\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband availability",
    "type": "GET",
    "url": "/broadband/availability/{cli_or_postcode}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Availability",
    "controller_name": "BroadbandAvailabilityController",
    "controller": "Methods for provisionally checking your ability to receive Broadband services from ICUK.",
    "description": "Search for your phone number or postcode and return a list of available broadband products with the speeds available.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "cli_or_postcode",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Phone number or postcode."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_availability_results'>broadband_availability_results</a>",
            "field": "availability",
            "optional": false,
            "description": "Represents broadband availability results."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"exchange\": {\n        \"status\": \"\",\n        \"message\": \"\",\n        \"exchange_code\": \"\",\n        \"exchange_name\": \"\"\n    },\n    \"products\": [\n        {\n            \"name\": \"\",\n            \"likely_down_speed\": 0,\n            \"likely_up_speed\": 0,\n            \"availability\": true\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband availability for exact address",
    "type": "POST",
    "url": "/broadband/availability",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Availability",
    "controller_name": "BroadbandAvailabilityController",
    "controller": "Methods for provisionally checking your ability to receive Broadband services from ICUK.",
    "description": "Search with your exact BT address match and return a list of available broadband products with the speeds available.",
    "parameter": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_address'>broadband_address</a>",
            "field": "address",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_address struct."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_availability_results'>broadband_availability_results</a>",
            "field": "availability",
            "optional": false,
            "description": "Represents broadband availability results."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/availability/\n{\n    \"postcode\": \"\",\n    \"district_id\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"exchange\": {\n        \"status\": \"\",\n        \"message\": \"\",\n        \"exchange_code\": \"\",\n        \"exchange_name\": \"\"\n    },\n    \"products\": [\n        {\n            \"name\": \"\",\n            \"likely_down_speed\": 0,\n            \"likely_up_speed\": 0,\n            \"availability\": true\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband contact details",
    "type": "GET",
    "url": "/broadband/user/contact/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Contact",
    "controller_name": "BroadbandContactController",
    "controller": "Methods for provisionally checking your ability to receive Broadband services from ICUK.",
    "description": "Retrieves the contact details for a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_user_contact'>broadband_user_contact</a>",
            "field": "password",
            "optional": false,
            "description": "broadband_user_password struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"forename\": \"\",\n    \"surname\": \"\",\n    \"phone\": \"\",\n    \"email\": \"\"\n}\n"
        }
        ]
    }
},
{
    "name": "Updates broadband contact details",
    "type": "PUT",
    "url": "/broadband/user/contact/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Contact",
    "controller_name": "BroadbandContactController",
    "controller": "Methods for provisionally checking your ability to receive Broadband services from ICUK.",
    "description": "Changes a broadband users contact details.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_user_contact'>broadband_user_contact</a>",
            "field": "contact",
            "optional": true,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_user_contact struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "PUT /broadband/user/contact/{user@realm}\n{\n    \"forename\": \"\",\n    \"surname\": \"\",\n    \"phone\": \"\",\n    \"email\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n/broadband/user/contact/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Gets daily broadband transfer usage for current month",
    "type": "GET",
    "url": "/broadband/data_transfer/daily/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the daily data transfer usage for a broadband user for the current month.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_daily_result'>broadband_data_transfer_daily_result</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage of a specific user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"year\": 2014,\n    \"month\": 1,\n    \"days\": [\n        {\n            \"off_peak\": {\n                \"download\": 0,\n                \"upload\": 0\n            },\n            \"peak\": {\n                \"download\": 0,\n                \"upload\": 0\n            },\n            \"day\": 1\n        }\n    ]    \n}\n"
        }
        ]
    }
},
{
    "name": "Gets daily broadband transfer usage for month and year",
    "type": "GET",
    "url": "/broadband/data_transfer/daily/{user@realm}/{year}/{month}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the daily data transfer usage for a broadband user for the specified month and year.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Month."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_daily_result'>broadband_data_transfer_daily_result</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage of a specific user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"year\": 2014,\n    \"month\": 1,\n    \"days\": [\n        {\n            \"off_peak\": {\n                \"download\": 0,\n                \"upload\": 0\n            },\n            \"peak\": {\n                \"download\": 0,\n                \"upload\": 0\n            },\n            \"day\": 1\n        }\n    ]    \n}\n"
        }
        ]
    }
},
{
    "name": "Gets hourly broadband transfer usage for current day",
    "type": "GET",
    "url": "/broadband/data_transfer/hourly/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the hourly data transfer usage for a broadband user for the current day.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_hourly_result'>broadband_data_transfer_hourly_result</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage of a specific user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"year\": 2014,\n    \"month\": 1,\n    \"day\": 1,\n    \"hours\": [\n        {\n            \"download\": 0,\n            \"upload\": 0,\n            \"hour\": 8\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets hourly broadband transfer usage for day, month and year",
    "type": "GET",
    "url": "/broadband/data_transfer/hourly/{user@realm}/{year}/{month}/{day}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the hourly data transfer usage for a broadband user for the specified day, month and year.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Month."
        },
        {
            "type": "Integer",
            "field": "day",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Day."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_hourly_result'>broadband_data_transfer_hourly_result</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage of a specific user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"year\": 2014,\n    \"month\": 1,\n    \"day\": 1,\n    \"hours\": [\n        {\n            \"download\": 0,\n            \"upload\": 0,\n            \"hour\": 8\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets monthly broadband transfer usage for all users for the current month",
    "type": "GET",
    "url": "/broadband/data_transfer/monthly",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the monthly data transfer usage for all users for the current month.",
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_results'>broadband_data_transfer_monthly_results</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage for all users."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"data_transfers\": [\n        {\n            \"username\": \"user@realm.co.uk\",\n            \"year\": 2014,\n            \"month\": 1,\n            \"peak_hours\": {\n                \"start\": \"08:00:00\",\n                \"end\": \"19:59:59\"\n            },\n            \"off_peak\": {\n                \"download\": {\n                    \"quota\": 0,\n                    \"usage\": 0,\n                    \"overuse\": 0,\n                    \"projected\": 0,\n                    \"projected_overuse\": 0\n                },\n                \"upload\": {\n                    \"usage\": 0,\n                    \"projected\": 0\n                }\n            },\n            \"peak\": {...},\n            \"total\": {...}\n        }\n    ] \n}\n"
        }
        ]
    }
},
{
    "name": "Gets monthly broadband transfer usage for the current month",
    "type": "GET",
    "url": "/broadband/data_transfer/monthly/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the monthly data transfer usage for a broadband user for the current month.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_result'>broadband_data_transfer_monthly_result</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage of a specific user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"year\": 2014,\n    \"month\": 1,\n    \"peak_hours\": {\n        \"start\": \"08:00:00\",\n        \"end\": \"19:59:59\"\n    },\n    \"off_peak\": {\n        \"download\": {\n            \"quota\": 0,\n            \"usage\": 0,\n            \"overuse\": 0,\n            \"projected\": 0,\n            \"projected_overuse\": 0\n        },\n        \"upload\": {\n            \"usage\": 0,\n            \"projected\": 0\n        }\n    },\n    \"peak\": {...},\n    \"total\": {...}\n}\n"
        }
        ]
    }
},
{
    "name": "Gets monthly broadband transfer usage for all users for specified month and year",
    "type": "GET",
    "url": "/broadband/data_transfer/monthly/{year}/{month}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the monthly data transfer usage for all users for the specified month and year.",
    "parameter": {
        "fields": [
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Month."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_results'>broadband_data_transfer_monthly_results</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage for all users."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"data_transfers\": [\n        {\n            \"username\": \"user@realm.co.uk\",\n            \"year\": 2014,\n            \"month\": 1,\n            \"peak_hours\": {\n                \"start\": \"08:00:00\",\n                \"end\": \"19:59:59\"\n            },\n            \"off_peak\": {\n                \"download\": {\n                    \"quota\": 0,\n                    \"usage\": 0,\n                    \"overuse\": 0,\n                    \"projected\": 0,\n                    \"projected_overuse\": 0\n                },\n                \"upload\": {\n                    \"usage\": 0,\n                    \"projected\": 0\n                }\n            },\n            \"peak\": {...},\n            \"total\": {...}\n        }\n    ] \n}\n"
        }
        ]
    }
},
{
    "name": "Gets monthly broadband transfer usage for specified month and year",
    "type": "GET",
    "url": "/broadband/data_transfer/monthly/{user@realm}/{year}/{month}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Data Transfer",
    "controller_name": "BroadbandDataTransferController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the monthly data transfer usage for a broadband user for the specified month and year.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "Integer",
            "field": "year",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Year."
        },
        {
            "type": "Integer",
            "field": "month",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Month."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_data_transfer_monthly_result'>broadband_data_transfer_monthly_result</a>",
            "field": "data_transfer",
            "optional": false,
            "description": "Represents broadband data transfer usage of a specific user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DataUsageException",
            "description": "Unable to retrieve data usage."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"year\": 2014,\n    \"month\": 1,\n    \"peak_hours\": {\n        \"start\": \"08:00:00\",\n        \"end\": \"19:59:59\"\n    },\n    \"off_peak\": {\n        \"download\": {\n            \"quota\": 0,\n            \"usage\": 0,\n            \"overuse\": 0,\n            \"projected\": 0,\n            \"projected_overuse\": 0\n        },\n        \"upload\": {\n            \"usage\": 0,\n            \"projected\": 0\n        }\n    },\n    \"peak\": {...},\n    \"total\": {...}\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband IP information",
    "type": "GET",
    "url": "/broadband/ip/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpController",
    "controller": "Methods for creating, retrieving, updating and deleting IP addresses for a broadband user.",
    "description": "Retrieves the static, routed and Ipv6 information of a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_ip_results'>broadband_ip_results</a>",
            "field": "ip_results",
            "optional": false,
            "description": "broadband_ip_results struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"ip\": \"48.34.135.1\",\n    \"allocation\": \"static\",\n    \"routed\": [\n        {\n            \"ip\": \"48.34.135.1\",\n            \"network\": \"48.34.135.1\",\n            \"netmask\": \"255.255.255.255\",\n            \"usable\": [\n                \"48.34.135.1\"\n            ],\n            \"broadcast\": \"48.34.135.1\"\n        }\n    ],\n    \"ipv6\": {\n        \"ip\": \"2005:0db9:85a3:0046:1000:8a4e:0370:7334\",\n        \"network\": \"2005:0DB9:0000:0000:0000:0000:0000:0000\",\n        \"netmask\": \"FFFF:FFFF:0000:0000:0000:0000:0000:0000\",\n        \"range\": 1,\n        \"broadcast\": \"2005:0DB9:FFFF:FFFF:FFFF:FFFF:FFFF:FFFF\" \n    }\n}\n"
        }
        ]
    }
},
{
    "name": "Assigns a static IPv4 address",
    "type": "POST",
    "url": "/broadband/ip/static/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpController",
    "controller": "Methods for creating, retrieving, updating and deleting IP addresses for a broadband user.",
    "description": "Assigns a static IPv4 address to a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        },
        {
            "field": "PaymentException",
            "description": "Your card details have been declined."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/ip/static/{user@realm}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/ip/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Assigns a routed IPv4 address",
    "type": "POST",
    "url": "/broadband/ip/routed/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpController",
    "controller": "Methods for creating, retrieving, updating and deleting IP addresses for a broadband user.",
    "description": "Assigns a routed IPv4 address of the supplied size to a broadband user and updates the RIPE database with the supplied RIPE NIC handle. If the current allocation is dynamic a static IP will also be created.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_ip_allocation'>broadband_ip_allocation</a>",
            "field": "ip_allocation",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_ip_allocation struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        },
        {
            "field": "PaymentException",
            "description": "Your card details have been declined."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/ip/routed/{user@realm}\n{\n    \"prefix\": \"\",\n    \"ripe_admin_nic_handle\": \"\",\n    \"ripe_tech_nic_handle\": \"\",\n    \"justification\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/ip/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Removes a static IP address",
    "type": "DELETE",
    "url": "/broadband/ip/static/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpController",
    "controller": "Methods for creating, retrieving, updating and deleting IP addresses for a broadband user.",
    "description": "Removes a static IP address and all routed subnets from a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        },
        {
            "field": "DeleteResourceException",
            "description": "Unable to delete resource."
        },
        {
            "field": "PaymentException",
            "description": "Your card details have been declined."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n"
        }
        ]
    }
},
{
    "name": "Removes a routed subnet",
    "type": "DELETE",
    "url": "/broadband/ip/routed/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpController",
    "controller": "Methods for creating, retrieving, updating and deleting IP addresses for a broadband user.",
    "description": "Removes a routed subnet from a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_ip_deallocation'>broadband_ip_deallocation</a>",
            "field": "ip_deallocation",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_ip_deallocation struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        },
        {
            "field": "DeleteResourceException",
            "description": "Unable to delete resource."
        },
        {
            "field": "PaymentException",
            "description": "Your card details have been declined."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "DELETE /broadband/ip/routed/{user@realm}\n{\n    \"prefix\": 0,\n    \"ip\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n"
        }
        ]
    }
},
{
    "name": "Assigns a IPv6 address",
    "type": "POST",
    "url": "/broadband/ipv6/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpv6Controller",
    "controller": "Methods for creating, retrieving, updating and deleting IPv6 addresses for a broadband user.",
    "description": "Assigns a IPv6 address to a broadband user",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/ipv6/{user@realm}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/ip/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Removes a IPv6 address",
    "type": "DELETE",
    "url": "/broadband/ipv6/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband IP",
    "controller_name": "BroadbandIpv6Controller",
    "controller": "Methods for creating, retrieving, updating and deleting IPv6 addresses for a broadband user.",
    "description": "Removes a IPv6 address from a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DeleteResourceException",
            "description": "Unable to delete resource."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n"
        }
        ]
    }
},
{
    "name": "Orders a broadband product",
    "type": "POST",
    "url": "/broadband/order/provide",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Orders a new ADSL broadband product for a telephone line or address that does not currently have ADSL installed.",
    "parameter": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_details'>broadband_order_details</a>",
            "field": "order",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_order_details struct."
        },
        {
            "type": "<a href='#api-Type-broadband_order_customer'>broadband_order_customer</a>",
            "field": "customer",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_order_customer struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "PasswordException",
            "description": "Invalid password supplied."
        },
        {
            "field": "PaymentException",
            "description": "Your card details have been declined."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/order/provide\n{\n    \"order\": {\n        \"username\": \"user@realm.co.uk\",\n        \"password\": \"\",\n        \"simultaneous_provide\": false,\n        \"bt_order_reference\": \"\",\n        \"product_id\": 0,\n        \"activation_date\": \"2014-03-19\",\n        \"losing_isp\": \"unknown\",\n        \"fast_track\": false,\n        \"care_level\": \"STANDARD\",\n        \"send_completion_email\": false,\n        \"customer\": {\n            \"forename\": \"\",\n            \"surname\": \"\",\n            \"address\": {\n                \"house_name\": \"\",\n                \"street_name\": \"\",\n                \"town\": \"\",\n                \"county\": \"\",\n                \"post_code\": \"\"\n            },\n            \"contact\": {\n                \"contact_number\": \"\",\n                \"contact_mobile\": \"\",\n                \"email_address\": \"\"\n            }\n        }\n    }\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/user/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Orders a migration to a broadband product",
    "type": "POST",
    "url": "/broadband/order/migrate",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Orders a migration of an existing ADSL broadband connection for a telephone line or address.",
    "parameter": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_details'>broadband_order_details</a>",
            "field": "order",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_order_details struct."
        },
        {
            "type": "<a href='#api-Type-broadband_order_customer'>broadband_order_customer</a>",
            "field": "customer",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_order_customer struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "PasswordException",
            "description": "Invalid password supplied."
        },
        {
            "field": "PaymentException",
            "description": "Your card details have been declined."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/order/migrate\n{\n    \"order\": {\n        \"username\": \"user@realm.co.uk\",\n        \"password\": \"\",\n        \"simultaneous_provide\": false,\n        \"bt_order_reference\": \"\",\n        \"product_id\": 0,\n        \"activation_date\": \"2014-03-19\",\n        \"mac_code\": \"\",\n        \"losing_isp\": \"unknown\",\n        \"fast_track\": false,\n        \"care_level\": \"STANDARD\",\n        \"send_completion_email\": false,\n        \"customer\": {\n            \"forename\": \"\",\n            \"surname\": \"\",\n            \"address\": {\n                \"house_name\": \"\",\n                \"street_name\": \"\",\n                \"town\": \"\",\n                \"county\": \"\",\n                \"post_code\": \"\"\n            },\n            \"contact\": {\n                \"contact_number\": \"\",\n                \"contact_mobile\": \"\",\n                \"email_address\": \"\"\n            }\n        }\n    }\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/user/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Ceases a broadband user",
    "type": "POST",
    "url": "/broadband/order/cease/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Places a cease order for a existing ADSL broadband connection for a specific date.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_order_cease'>broadband_order_cease</a>",
            "field": "cease",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_order_cease struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/user/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband order summary for order type and status",
    "type": "GET",
    "url": "/broadband/order/{order_type}/{order_status}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Retrieves the broadband order summary for all users for the specified order type and status.",
    "parameter": {
        "fields": [
        {
            "type": "<a href='#api-Enum-broadband_order_type'>broadband_order_type</a>",
            "field": "order_type",
            "optional": true,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Order type."
        },
        {
            "type": "<a href='#api-Enum-broadband_order_status'>broadband_order_status</a>",
            "field": "order_status",
            "optional": true,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Order status."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_summary'>broadband_order_summary[]</a>",
            "field": "broadband_orders",
            "optional": false,
            "description": "Array of broadband_order_summary structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"broadband_orders\": [\n        {\n            \"order_id\": 0,\n            \"reference\": \"\",\n            \"product_id\": 0,\n            \"technology\": \"\",\n            \"cli\": \"\",\n            \"mac_code\": \"\",\n            \"username\": \"user@realm.co.uk\",\n            \"order_type\": \"PROVIDE\",\n            \"order_subtype\": \"PROVIDE_DIRECTORY_NUMBER\",\n            \"order_status\": \"COMPLETE\",\n            \"order_date\": \"2014-01-01T08:00:00\",\n            \"required_date\": \"2014-01-01T19:59:59\",\n            \"last_update\": \"2014-01-01T19:59:59\"\n       }\n   ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband order summary",
    "type": "GET",
    "url": "/broadband/order",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Retrieves the broadband order summary for all users.",
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_summary'>broadband_order_summary[]</a>",
            "field": "broadband_orders",
            "optional": false,
            "description": "Array of broadband_order_summary structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"broadband_orders\": [\n        {\n            \"order_id\": 0,\n            \"reference\": \"\",\n            \"product_id\": 0,\n            \"technology\": \"\",\n            \"cli\": \"\",\n            \"mac_code\": \"\",\n            \"username\": \"user@realm.co.uk\",\n            \"order_type\": \"PROVIDE\",\n            \"order_subtype\": \"PROVIDE_DIRECTORY_NUMBER\",\n            \"order_status\": \"COMPLETE\",\n            \"order_date\": \"2014-01-01T08:00:00\",\n            \"required_date\": \"2014-01-01T19:59:59\",\n            \"last_update\": \"2014-01-01T19:59:59\"\n       }\n   ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband order updates",
    "type": "GET",
    "url": "/broadband/order/updates/{start_date}/{end_date}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Retrieves the broadband orders which have been updated within a datetime range.",
    "parameter": {
        "fields": [
        {
            "type": "DateTime",
            "field": "start_date",
            "optional": false,
            "frombody": false,
            "day": -5,
            "time": true,
            "date": true,
            "description": "Start date."
        },
        {
            "type": "DateTime",
            "field": "end_date",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": true,
            "date": true,
            "description": "End date."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_information'>broadband_order_information[]</a>",
            "field": "orders_updates",
            "optional": false,
            "description": "Array of broadband_order_information structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"order_updates\": [\n        {\n            \"order_summary\": {\n                \"order_id\": 0,\n                \"reference\": \"\",\n                \"product_id\": 0,\n                \"technology\": \"\",\n                \"cli\": \"\",\n                \"mac_code\": \"\",\n                \"username\": \"user@realm.co.uk\",\n                \"order_type\": \"PROVIDE\",\n                \"order_subtype\": \"PROVIDE_DIRECTORY_NUMBER\",\n                \"order_status\": \"COMPLETE\",\n                \"order_date\": \"2014-01-01T08:00:00\",\n                \"required_date\": \"2014-01-01T19:59:59\",\n                \"last_update\": \"2014-01-01T19:59:59\"\n            },\n            \"broadband_user\": {\n                \"username\": \"user@realm.co.uk\",\n                \"password\": \"\",\n                \"cli\": \"\",\n                \"product\": \"\",\n                \"postcode\": \"\",\n                \"forename\": \"\",\n                \"surname\": \"\",\n                \"installation_address\": {\n                    \"house_name\": \"\",\n                    \"street_name\": \"\",\n                    \"town\": \"\",\n                    \"county\": \"\",\n                    \"postcode\": \"\"\n                },\n                \"is_online\": false\n            },\n            \"order_history\": {\n                \"order_events\": [\n                    {\n                        \"date\": \"2014-01-01T08:00:00\",\n                        \"name\": \"\",\n                        \"description\": \"\"\n                    }\n                ]\n            }\n        }             \n    ]     \n}\n"
        }
        ]
    }
},
{
    "name": "Gets a broadband order update",
    "type": "GET",
    "url": "/broadband/order/updates/{order_id}/{start_date}/{end_date}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Retrieves a specific broadband order which has been updated within a datetime range.",
    "parameter": {
        "fields": [
        {
            "type": "Integer",
            "field": "order_id",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Broadband order ID."
        },
        {
            "type": "DateTime",
            "field": "start_date",
            "optional": false,
            "frombody": false,
            "day": -5,
            "time": true,
            "date": true,
            "description": "Start date."
        },
        {
            "type": "DateTime",
            "field": "end_date",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": true,
            "date": true,
            "description": "End date."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_information'>broadband_order_information</a>",
            "field": "order_update",
            "optional": false,
            "description": "broadband_order_information struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"order_summary\": {\n        \"order_id\": 0,\n        \"reference\": \"\",\n        \"product_id\": 0,\n        \"technology\": \"\",\n        \"cli\": \"\",\n        \"mac_code\": \"\",\n        \"username\": \"user@realm.co.uk\",\n        \"order_type\": \"PROVIDE\",\n        \"order_subtype\": \"PROVIDE_DIRECTORY_NUMBER\",\n        \"order_status\": \"COMPLETE\",\n        \"order_date\": \"2014-01-01T08:00:00\",\n        \"required_date\": \"2014-01-01T19:59:59\",\n        \"last_update\": \"2014-01-01T19:59:59\"\n    },\n    \"broadband_user\": {\n         \"username\": \"user@realm.co.uk\",\n         \"password\": \"\",\n         \"cli\": \"\",\n         \"product\": \"\",\n         \"postcode\": \"\",\n         \"forename\": \"\",\n         \"surname\": \"\",\n         \"installation_address\": {\n            \"house_name\": \"\",\n            \"street_name\": \"\",\n            \"town\": \"\",\n            \"county\": \"\",\n            \"postcode\": \"\"\n         }, \n         \"is_online\": false\n    },\n    \"order_history\": {\n        \"order_events\": [\n            {\n               \"date\": \"2014-01-01T08:00:00\",\n               \"name\": \"\",\n               \"description\": \"\"\n            }\n        ]\n    }\n}\n"
        }
        ]
    }
},
{
    "name": "Gets a broadband order details",
    "type": "GET",
    "url": "/broadband/order/{order_id}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Order",
    "controller_name": "BroadbandOrderController",
    "controller": "Methods for ordering broadband products.",
    "description": "Retrieves the broadband order details for a broadband order ID.",
    "parameter": {
        "fields": [
        {
            "type": "Integer",
            "field": "order_id",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Order ID."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_order_information'>broadband_order_information</a>",
            "field": "broadband_order",
            "optional": false,
            "description": "broadband_order_information struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"order_summary\": {\n        \"order_id\": 0,\n        \"reference\": \"\",\n        \"product_id\": 0,\n        \"technology\": \"\",\n        \"cli\": \"\",\n        \"mac_code\": \"\",\n        \"username\": \"user@realm.co.uk\",\n        \"order_type\": \"PROVIDE\",\n        \"order_subtype\": \"PROVIDE_DIRECTORY_NUMBER\",\n        \"order_status\": \"COMPLETE\",\n        \"order_date\": \"2014-01-01T08:00:00\",\n        \"required_date\": \"2014-01-01T19:59:59\",\n        \"last_update\": \"2014-01-01T19:59:59\"\n    },\n    \"broadband_user\": {\n         \"username\": \"user@realm.co.uk\",\n         \"password\": \"\",\n         \"cli\": \"\",\n         \"product\": \"\",\n         \"postcode\": \"\",\n         \"forename\": \"\",\n         \"surname\": \"\",\n         \"installation_address\": {\n            \"house_name\": \"\",\n            \"street_name\": \"\",\n            \"town\": \"\",\n            \"county\": \"\",\n            \"postcode\": \"\"\n         },\n         \"is_online\": false\n    },\n    \"order_history\": {\n        \"order_events\": [\n            {\n               \"date\": \"2014-01-01T08:00:00\",\n               \"name\": \"\",\n               \"description\": \"\"\n            }\n        ]\n    }\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband password",
    "type": "GET",
    "url": "/broadband/user/password/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Password",
    "controller_name": "BroadbandPasswordController",
    "controller": "Methods for retrieving and updating the password of a broadband user.",
    "description": "Retrieves the password of a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_user_password'>broadband_user_password</a>",
            "field": "password",
            "optional": false,
            "description": "broadband_user_password struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "PasswordException",
            "description": "Invalid password supplied."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"password\": \"\"   \n}\n"
        }
        ]
    }
},
{
    "name": "Updates broadband password",
    "type": "PUT",
    "url": "/broadband/user/password/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Password",
    "controller_name": "BroadbandPasswordController",
    "controller": "Methods for retrieving and updating the password of a broadband user.",
    "description": "Updates password of a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        },
        {
            "type": "<a href='#api-Type-broadband_user_password'>broadband_user_password</a>",
            "field": "password",
            "optional": true,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_user_password struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "PasswordException",
            "description": "Invalid password supplied."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "PUT /broadband/user/password/{user@realm}\n{\n    \"password\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n/broadband/user/password/{user@realm}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband products available to reseller",
    "type": "GET",
    "url": "/broadband/products",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Products",
    "controller_name": "BroadbandProductController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the reseller's available broadband products that can be ordered and their costs.",
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_product_results'>broadband_product_results</a>",
            "field": "broadband_product_results",
            "optional": false,
            "description": "broadband_product_results struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"ip\": [\n        {\n            \"name\": \"Static IP Address\",\n            \"category\": \"IP\",\n            \"price\": 1\n        }\n    ],\n    \"routed\": [\n        {\n            \"name\": \"Routed /30 IPv4 Subnet\",\n            \"category\": \"Routed\",\n            \"price\": 4,\n            \"prefix\": 30\n        }\n    ],\n    \"elevated_best_effort\": [\n        {\n            \"name\": \"Elevated Best Effort\",\n            \"category\": \"Elevated Best Effort\",\n            \"price\": 3\n        }\n    ],\n    \"care\": [\n        {\n            \"name\": \"Enhanced\",\n            \"price\": 15,\n            \"category\": \"Care\",\n            \"care_level\": 2\n        }\n    ],\n    \"assured_rate\": [\n        {\n            \"name\": \"Assured Rate\",\n            \"category\": \"Assured Rate\",\n            \"price\": 0.5\n        }\n    ],\n    \"broadband_product\": [\n        {\n            \"id\": 153,\n            \"name\": \"Home 2GB Capped 20CN 512k\",\n            \"category\": \"Home ADSL Broadband Products\",\n            \"price\": 8.5,\n            \"fast_track_price\": 200,\n            \"provider\": \"WBC - 20CN\",\n            \"technology\": \"ADSL\",\n            \"down_speed\": 512,\n            \"up_speed\": 256,\n            \"peak_cap\": 2,\n            \"off_peak_cap\": 100,\n            \"contention\": 50,\n            \"product_class\": \"Home\",\n            \"provider_lead_time\": 7,\n            \"migration_lead_time\": 7,\n            \"peak_start\": \"08:00:00\",\n            \"peak_end\": \"19:59:59\",\n            \"contract_length\": 1,\n            \"legacy_product\": false,\n            \"requires_out_line_rental\": false,\n            \"unlimeted_cap\": false\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband ADSL product for a product ID",
    "type": "GET",
    "url": "/broadband/products/adsl/{product_id}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Products",
    "controller_name": "BroadbandProductController",
    "controller": "Methods for retrieving the daily data transfer usage of broadband users.",
    "description": "Retrieves the reseller's ADSL product details for a specific product ID.",
    "parameter": {
        "fields": [
        {
            "type": "Integer",
            "field": "product_id",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Broadband ADSL product ID."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_product'>broadband_product</a>",
            "field": "broadband_product",
            "optional": false,
            "description": "broadband_product struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"id\": 153,\n    \"name\": \"Home 2GB Capped 20CN 512k\",\n    \"category\": \"Home ADSL Broadband Products\",\n    \"price\": 8.5,\n    \"fast_track_price\": 200,\n    \"provider\": \"WBC - 20CN\",\n    \"technology\": \"ADSL\",\n    \"down_speed\": 512,\n    \"up_speed\": 256,\n    \"peak_cap\": 2,\n    \"off_peak_cap\": 100,\n    \"contention\": 50,\n    \"product_class\": \"Home\",\n    \"provider_lead_time\": 7,\n    \"migration_lead_time\": 7,\n    \"peak_start\": \"08:00:00\",\n    \"peak_end\": \"19:59:59\",\n    \"contract_length\": 1,\n    \"legacy_product\": false,\n    \"requires_out_line_rental\": false,\n    \"unlimeted_cap\": false\n}\n"
        }
        ]
    }
},
{
    "name": "Gets RIPE person contacts that have been created",
    "type": "GET",
    "url": "/broadband/ripe/person",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband RIPE Person",
    "controller_name": "BroadbandRipePersonController",
    "controller": "Methods for creating, retrieving, updating and deleting RIPE person contact details.",
    "description": "Retrieves the RIPE person contacts that have been created for broadband accounts assigned to the reseller.",
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_ripe_person'>broadband_ripe_person[]</a>",
            "field": "ripe_persons",
            "optional": false,
            "description": "Array of broadband_ripe_person[] structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"ripe_persons\": [\n        {\n            \"name\": \"\",\n            \"nic_handle\": \"\",\n            \"mnt_by\": \"\",\n            \"address_line_1\": \"\",\n            \"address_line_2\": \"\",\n            \"town\": \"\",\n            \"county\": \"\",\n            \"postcode\": \"\",\n            \"phone_number\": \"\"\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets the RIPE person contacts for a specific nic-handle",
    "type": "GET",
    "url": "/broadband/ripe/person/{ripe_nic_handle}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband RIPE Person",
    "controller_name": "BroadbandRipePersonController",
    "controller": "Methods for creating, retrieving, updating and deleting RIPE person contact details.",
    "description": "Retrieves a RIPE person contact for a specific nic-handle that has been created for a broadband account assigned to the reseller.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "ripe_nic_handle",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "RIPE nic-handle."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_ripe_person'>broadband_ripe_person</a>",
            "field": "ripe_person",
            "optional": false,
            "description": "broadband_ripe_person struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"name\": \"\",\n    \"nic_handle\": \"\",\n    \"mnt_by\": \"\",\n    \"address_line_1\": \"\",\n    \"address_line_2\": \"\",\n    \"town\": \"\",\n    \"county\": \"\",\n    \"postcode\": \"\",\n    \"phone_number\": \"\"\n}\n"
        }
        ]
    }
},
{
    "name": "Creates a RIPE person contact details",
    "type": "POST",
    "url": "/broadband/ripe/person",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband RIPE Person",
    "controller_name": "BroadbandRipePersonController",
    "controller": "Methods for creating, retrieving, updating and deleting RIPE person contact details.",
    "description": "Creates a RIPE person contact assigned to the reseller.",
    "parameter": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_ripe_person'>broadband_ripe_person</a>",
            "field": "ripe_person",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_ripe_person struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "POST /broadband/ripe/person\n{\n    \"name\": \"\",\n    \"address_line_1\": \"\",\n    \"address_line_2\": \"\",\n    \"town\": \"\",\n    \"county\": \"\",\n    \"postcode\": \"\",\n    \"phone_number\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 201 OK\n/broadband/ripe/person/{ripe_nic_handle}\n"
        }
        ]
    }
},
{
    "name": "Updates the RIPE person contact details for a nic-handle",
    "type": "PUT",
    "url": "/broadband/ripe/person/{ripe_nic_handle}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband RIPE Person",
    "controller_name": "BroadbandRipePersonController",
    "controller": "Methods for creating, retrieving, updating and deleting RIPE person contact details.",
    "description": "Changes the RIPE person contact details for a nic-handle.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "ripe_nic_handle",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "RIPE nic-handle."
        },
        {
            "type": "<a href='#api-Type-broadband_ripe_person'>broadband_ripe_person</a>",
            "field": "ripe_person",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "broadband_ripe_person struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Request",
            "content": "PUT /broadband/ripe/person/{ripe_nic_handle}\n{\n    \"name\": \"\",\n    \"address_line_1\": \"\",\n    \"address_line_2\": \"\",\n    \"town\": \"\",\n    \"county\": \"\",\n    \"postcode\": \"\",\n    \"phone_number\": \"\"\n}\n"
        },
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n/broadband/ripe/person/{ripe_nic_handle}\n"
        }
        ]
    }
},
{
    "name": "Deletes the RIPE person contact details for a nic-handle",
    "type": "DELETE",
    "url": "/broadband/ripe/person/{ripe_nic_handle}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband RIPE Person",
    "controller_name": "BroadbandRipePersonController",
    "controller": "Methods for creating, retrieving, updating and deleting RIPE person contact details.",
    "description": "Deletes the RIPE person contact details for a nic-handle.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "ripe_nic_handle",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "RIPE nic-handle."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "DeleteResourceException",
            "description": "Unable to delete resource."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n"
        }
        ]
    }
},
{
    "name": "Gets broadband session history",
    "type": "GET",
    "url": "/broadband/session_history/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Session",
    "controller_name": "BroadbandSessionController",
    "controller": "Methods for retrieving the session history of broadband users.",
    "description": "Retrieves the past 50 session history of a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_session_history'>broadband_session_history[]</a>",
            "field": "session_history",
            "optional": false,
            "description": "Array of broadband_session_history structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"session_history\": [\n        {\n            \"username\": \"user@realm.co.uk\",\n            \"framed_ip\": \"48.34.135.1\",\n            \"start_time\": \"2014-01-01T08:00:00\",\n            \"stop_time\": \"2014-01-01T19:59:59\",\n            \"time_online\": \"11 hours 59 minutes 59 seconds\",\n            \"data_in\": 0,\n            \"data_out\": 0,\n            \"termination_cause\": \"\"\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets broadband online statuses for all users",
    "type": "GET",
    "url": "/broadband/online_status",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Status",
    "controller_name": "BroadbandStatusController",
    "controller": "Methods for retrieving the online statuses of broadband users.",
    "description": "Retrieves the online statuses for all broadband users.",
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_online_status_results'>broadband_online_status_results</a>",
            "field": "online_statuses",
            "optional": false,
            "description": "broadband_online_status_results struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"online_statuses\": [\n        {\n            \"username\": \"user@realm.co.uk\",\n            \"login_time\": \"2014-01-01T08:00:00\",\n            \"time_online\": \"11 hours 59 minutes 59 seconds\",\n            \"is_online\": true\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Get broadband online status",
    "type": "GET",
    "url": "/broadband/online_status/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Status",
    "controller_name": "BroadbandStatusController",
    "controller": "Methods for retrieving the online statuses of broadband users.",
    "description": "Retrieves the online status of a broadband user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_online_status'>broadband_online_status</a>",
            "field": "onlinestatus",
            "optional": false,
            "description": "broadband_online_status struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"login_time\": \"2014-01-01T08:00:00\",\n    \"time_online\": \"11 hours 59 minutes 59 seconds\",\n    \"is_online\": true\n}\n"
        }
        ]
    }
},
{
    "name": "Deletes the session of an online broadband user",
    "type": "DELETE",
    "url": "/broadband/online_status/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband Status",
    "controller_name": "BroadbandStatusController",
    "controller": "Methods for retrieving the online statuses of broadband users.",
    "description": "Terminates a user's session if they are online.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_online_status_termination'>broadband_online_status_termination</a>",
            "field": "online_status",
            "optional": false,
            "description": "broadband_online_status_termination struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"message\": \"\",\n    \"is_success_response\": true   \n}\n"
        }
        ]
    }
},
{
    "name": "Gets all broadand users",
    "type": "GET",
    "url": "/broadband/user",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband User",
    "controller_name": "BroadbandUserController",
    "controller": "Methods for retrieving, creating, updating and deleting broadband users.",
    "description": "Retrieves all the broadband users belonging to the API user.",
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_user'>broadband_user[]</a>",
            "field": "broadband_users",
            "optional": false,
            "description": "Array of broadband_user structs."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"broadband_users\": [\n        {\n            \"username\": \"user@realm.co.uk\",\n            \"password\": \"\",\n            \"cli\": \"\",\n            \"product\": \"\",\n            \"forename\": \"\",\n            \"surname\": \"\",\n            \"installation_address\": {\n                \"house_name\": \"\",\n                \"street_name\": \"\",\n                \"town\": \"\",\n                \"county\": \"\",\n                \"postcode\": \"\"\n            },\n            \"is_online\": true\n        }\n    ]\n}\n"
        }
        ]
    }
},
{
    "name": "Gets a broadband user",
    "type": "GET",
    "url": "/broadband/user/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband User",
    "controller_name": "BroadbandUserController",
    "controller": "Methods for retrieving, creating, updating and deleting broadband users.",
    "description": "Retrieves a broadband user belonging to the API user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "success": {
        "fields": [
        {
            "type": "<a href='#api-Type-broadband_user'>broadband_user</a>",
            "field": "broadband_user",
            "optional": false,
            "description": "broadband_user struct."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "InternalApiException",
            "description": "Internal API exception occured."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 200 OK\n{\n    \"username\": \"user@realm.co.uk\",\n    \"password\": \"\",\n    \"cli\": \"\",\n    \"product\": \"\",\n    \"forename\": \"\",\n    \"surname\": \"\",\n    \"installation_address\": {\n        \"house_name\": \"\",\n        \"street_name\": \"\",\n        \"town\": \"\",\n        \"county\": \"\",\n        \"postcode\": \"\"\n    },\n    \"is_online\": true\n}\n"
        }
        ]
    }
},
{
    "name": "Deletes a broadband user",
    "type": "DELETE",
    "url": "/broadband/user/{user@realm}",
    "url_param": true,
    "user_type": 4,
    "group": "Broadband User",
    "controller_name": "BroadbandUserController",
    "controller": "Methods for retrieving, creating, updating and deleting broadband users.",
    "description": "Deletes a broadband user belonging to the API user.",
    "parameter": {
        "fields": [
        {
            "type": "String",
            "field": "username",
            "optional": false,
            "frombody": false,
            "day": 0,
            "time": false,
            "date": true,
            "description": "Name of the user."
        }
        ]
    },
    "error": {
        "fields": [
        {
            "field": "InvalidParameterException",
            "description": "Parameter is not valid."
        },
        {
            "field": "NonExistentUserException",
            "description": "User does not exist."
        },
        {
            "field": "NotLiveException",
            "description": "Account is not live."
        },
        {
            "field": "DeleteResourceException",
            "description": "Unable to delete resource."
        }
        ],
        "examples": [
        {
            "title": "Response",
            "content": "HTTP/1.1 204 OK\n"
        }
        ]
    }
}
]