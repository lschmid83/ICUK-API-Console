$(document).ready(function () {

    // Get the id attribute of the first menu item
    var id = $('.console-menu-method').first().attr('id');
    $('.console-menu-method').first().addClass('method-selected');

    // Initialize ajax request parameters
    var params = {
        action: 'method',
        module: id.split('-')[0],
        controller: id.split('-')[1],
        method: id.split('-')[2]
    };

    // Request initial controller method 
    jQuery.ajax({
        url: '/docs/console',
        data: params,
        dataType: 'html',
        success: function (data) {
            $('div.console-content').html(data);
            initFormHandler();
            initStructHandler();
            initMenuHandler()
            updateRequest();
        },
        error: function () {
        }
    });

    // Close search button
    $('#close-search').click(function () {
        $('#collapseSearch').collapse('toggle');
    });

    // Search field
    $('#search-field').on('input', function () {

        var params = {
            action: 'search',
            search_text: $('#search-field').val()
        };

        jQuery.ajax({
            url: '/docs/console',
            data: params,
            dataType: 'html',
            success: function (data) {

                // Collapse all open module categories
                if (data.length > 0) {
                    $('.panel-collapse').each(function () {
                        if ($(this).hasClass('in') && !$(this).is('#collapseSearch')) {
                            $(this).collapse('toggle');
                        }
                    });
                }

                // Update the search results
                $('div.search-results').html(data);

                // Bind click event for search results
                initMenuHandler()
            },
            error: function () {
            }
        });

    });
});

// Serialize a form into an array.
function formToObject(form, writeStruct) {

    var o = {};
    $(form).find(':input').each(function () {

        if ($(this).closest('div').is(":visible")) {

            var name = $(this).attr('name');
            var type = $(this).data('type');
            var value = $(this).val();

            // Add nested structs to object
            if ($(this).hasClass("btn-add-struct")) {

                // Get the field name and data type the button is associated with
                var field = $(this).data('field');
                var type = $(this).data('type');

                // Count number of nested elements added to field
                var count = 0;
                $(form).parent().find('.nested-message-param').each(function () {

                    if ($(this).data('type') == type && $(this).data('field') == field &&
                        $(this).parent().is(":visible")) {
                        count++;
                    }
                });

                // Construct JSON for nested elements
                $(form).parent().find('.nested-message-param').each(function () {

                    if ($(this).data('type') == type && $(this).data('field') == field) {

                        // Single item
                        if (count == 1) {
                            o[field] = formToObject($(this), true);
                        }
                        // Array of nested elements
                        else {
                            if (count > 1) {
                                // Unitialized array
                                if (o[field] == undefined) {
                                    o[field] = new Array();
                                    o[field].push(formToObject($(this), true));
                                }
                                // Push additional items into array
                                else {
                                    o[field].push(formToObject($(this), true));
                                }
                            }
                        }
                    }
                });
            }
            else {

                if (!$(this).closest('table').hasClass('nested-message-param') || writeStruct) {

                    if (type == 'Bool') {
                        if (value.toLowerCase() == 'true')
                            value = true;
                        else
                            value = false;
                    }

                    var optional = $(this).data('optional');

                    if (!optional || value != "") {
                        if (o[name] !== undefined) {
                            if (!o[name].push) {
                                o[name] = [o[name]];
                            }
                            if (type == 'Bool')
                                o[name].push(value);
                            else if (type == 'Integer' || type == 'Long' || type == 'Decimal')
                                o[name].push(+value); // 
                            else
                                o[name].push(value);
                        } else {
                            if (name !== undefined) {
                                if (type == 'Bool')
                                    o[name] = value;
                                else if (type == 'Integer' || type == 'Long' || type == 'Decimal')
                                    o[name] = +value;
                                else
                                    o[name] = value;
                            }
                        }
                    }
                }
            }
        }
    });

    return o;
}

// Serizlize an array to a query string.
function arrayToQueryString(array) {
    var result = '';
    for (var i = 0; i < array.length; i++) {
        if (array[i].value.length != 0) {

            if (result.length == 0)
                result += '?';

            if (i != 0 && result != '?')
                result += '&';

            result += array[i].name + '=' + escape(array[i].value.toLowerCase());
        }
    }
    return result;
}

// Serialize an array to a parameterized URL.
function arrayToParameterizedUrl(array) {
    var result = '';
    for (var i = 0; i < array.length; i++) {
        if (i != 0)
            result += '/';
        result += (array[i].value.length == 0) ? '{' + array[i].name + '}' : array[i].value.toLowerCase();
    }
    return result;
}

// Serializes method parameter form input to JSON and sends ajax request to update page contents.
function updateRequest() {

    var httpMethod = $('.method-name').data('type');
    var url = $('.method-name').data('url');
    var paramInUrl = $('.method-name').data('param-in-url');
    var messageBody;
    var lastArrayType;
    var fromBodyExists = false;
    var request = '';

    // Get the number of message body paramater form elements
    var numMessageParamForm = $('.message-param').length;
    messageBody = '';

    // Count number fields in root object
    var fields = $('.form-type-name').length;

    $('.method-example').each(function () {

        // URL parameter form
        if ($(this).hasClass('url-param')) {

            if (!paramInUrl) {
                // Serialize URL parameter form to query string
                var urlParam = arrayToQueryString($(this).find('.form-control').serializeArray());
            }
            else {
                // Handle domains where parameters are included in the URL 
                // For example: /hosting/domain/map/{domain}/{username}
                var urlParam = arrayToParameterizedUrl($(this).find('.form-control').serializeArray());
            }
            url += urlParam;
            $('.method-name').data('url-param', urlParam);
        }
        // Message body parameter forms
        else {

            // Ignore nested message parameter forms
            if (!$(this).hasClass('nested-message-param')) {

                // If type is part of an array
                if ($(this).data('type').indexOf('[]') !== -1) {

                    // First item in array 
                    if (lastArrayType == undefined && !fromBodyExists) {
                        messageBody = '{';
                    }

                    // Close array (Assumes multiple forms which represent arrays are grouped by type)
                    if (lastArrayType != undefined && lastArrayType != $(this).data('type')) {
                        messageBody = messageBody.substring(0, messageBody.length - 1); // Remove trailing comma
                        messageBody += '],';
                    }

                    // Label JSON array with field name
                    if (lastArrayType != $(this).data('type'))
                        messageBody += '"' + $(this).data('field') + '":[';

                    // Serialize the form input to JSON
                    messageBody += JSON.stringify(formToObject($(this), false)) + ',';

                    lastArrayType = $(this).data('type');
                }
                else {

                    // Close array if followed by a predefined struct
                    if (lastArrayType != undefined && lastArrayType != $(this).data('type')) {
                        messageBody = messageBody.substring(0, messageBody.length - 1);
                        messageBody += '],';
                        lastArrayType = null;
                    }

                    // Serialize the form input to JSON
                    if (fields == 1 || $(this).data('type') == 'frombody')
                        messageBody += JSON.stringify(formToObject($(this), false));
                    else {
                        messageBody += '"' + $(this).data('field') + '":' + JSON.stringify(formToObject($(this), false)) + ',';
                    }

                    // Data type <frombody> are additional parameters which are not defined in a struct,
                    // these can be used to create message body data which is up to three levels deep 
                    if ($(this).data('type') == 'frombody') {

                        // Additional parameters are defined in the root of the document
                        messageBody = '{' + messageBody.substring(1, messageBody.length - 1) + ',';
                        fromBodyExists = true;

                        // There are no structs defined after message body <frombody> parameters
                        if (numMessageParamForm == 1) {
                            messageBody = messageBody.substring(0, messageBody.length - 1) + '}';
                        }
                    }
                }
            }
        }
    });

    if (lastArrayType != undefined) {
        // Close array
        messageBody = messageBody.substring(0, messageBody.length - 1);
        messageBody += ']}';
    }
    else {
        // Add brackets to root object with multiple fields
        if (fields > 1)
            messageBody = '{' + messageBody.substring(0, messageBody.length - 1) + '}';
    }

    if (numMessageParamForm > 0) {

        // Parse JSON string into object
        var json = jQuery.parseJSON(messageBody);

        // Convert JSON object to well formatted string
        request = JSON.stringify(json, null, 3);
    }

    // Add HTTP method and request URL to message body
    request = httpMethod + ' ' + url + '\n' + request;

    // Update request example
    $('code.example-request').html(request);

}

// Displays the response example.
function updateResponse() {

    if ($('.chk-real-request').prop('checked')) {

        var httpMethod = $('.method-name').data('type');
        var urlParam = $('.method-name').data('url-param');
        (urlParam == undefined) ? urlParam = '' : urlParam = urlParam;
        var requestUrl = $('.method-name').data('url') + urlParam;
        var requestBody = $('.example-request').text().split("\n").slice(1).join("\n");
        var paramInUrl = $('.method-name').data('param-in-url');

        // Send real API request
        jQuery.ajax({
            type: "POST",
            url: '/docs/console?action=request',
            dataType: 'text',
            data: {
                url: requestUrl,
                method: httpMethod,
                message: requestBody
            },
            success: function (data, status, xhr) {

                // Get response header
                var responseHeader = 'HTTP/' + "<span style='color:#3387CC'>1.1 " + xhr.status + '</span> ' + xhr.statusText;

                var header_location = xhr.getResponseHeader("Location");

                if (header_location != null) {
                    responseHeader += '<br>' + header_location;
                }

                if (xhr.status == 200 && data.length > 0) {
                    // Parse JSON string into object
                    var json = jQuery.parseJSON(data);

                    // Convert JSON object to well formatted string
                    response = JSON.stringify(json, null, 3);

                    // Update response example
                    $('code.example-response').html(responseHeader + '\n' + response);
                    $('.btn-send-request').prop('disabled', false);
                }
                else {
                    $('code.example-response').html(responseHeader);
                    $('.btn-send-request').prop('disabled', false);
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                if (xhr.status != 404)
                    $('code.example-response').html(xhr.responseText);
                else
                    $('code.example-response').html(xhr.statusText);

                $('.btn-send-request').prop('disabled', false);
            }
        });
    }
    else {
        $('code.example-response').html($('code.example-response').data('example'));
        $('.btn-send-request').prop('disabled', false);
    }

    // Scroll to response content
    $('html, body').animate({
        scrollTop: $(".response-content").offset().top
    }, 500);
}

// Validate URL and message body form input fields are present.
function validateForm() {

    var validationError = false;
    var validationMessage = '';
    var fields = [];

    $('.method-example').each(function () {

        $(this).find(':input').each(function () {

            // Input is not optional
            var optional = $(this).data('optional');

            // Ignore nested struct buttons
            if ($(this).hasClass('btn-add-struct') || $(this).hasClass('btn-remove-struct') || $(this).hasClass('combobox')
                || $(this).hasClass('datetime') || $(this).hasClass('btn-datetime'))
                optional = true;

            // Ignore uninitialized nested structs
            if ($(this).closest('table').hasClass('nested-message-param') &&
                !$(this).closest("table").is(':visible')) {
                optional = true;
            }

            // Field is blank and not optional
            if ($(this).val() == 0 && $(this).prop('type') == 'text' && !optional) {

                validationError = true;

                // Add field name to array
                fields.push($(this).attr('name'));

                // Highlight the field
                $(this).addClass('input-highlight');
                $(this).addClass('validation-failed');
            }
        });

    });

    // Remove duplicate field names
    fields = $.grep(fields, function (v, k) {
        return $.inArray(v, fields) === k;
    });

    // Add event handlers to remove highlight if text is entered into field
    $('.form-control').on('input', function (e) {
        if ($(this).hasClass('validation-failed')) {
            if (isBlank($(this).val())) {
                $(this).addClass('input-highlight');
            }
            else {
                $(this).removeClass('input-highlight');
            }
        }
    });

    // Construct validation error dialog
    if (validationError) {

        var dialog = $('#console-dialog');
        dialog.find('.modal-title').html('Some problems occured...');
        validationMessage = '<p>Some information was entered incorrectly. The incorrect fields are listed below, and have been outlined in <span style="color:blue">blue</span> on the page.</p>';
        validationMessage += "<ul class='validation-field-list'>";
        for (var i = 0; i < fields.length; i++) {
            validationMessage += "<li>'" + fields[i] + "' cannot be blank</li>";
        }
        validationMessage += '</ul>';
        dialog.find('.modal-body').html(validationMessage);
        dialog.modal('show');
    }

    return !validationError;
}

// Determines whether a string is null or whitespace
function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

// Updates request when date picker is closed
function datePickerClosed(e) {
    updateRequest();
}

// Initializes event handlers for nested struct buttons.
function initStructHandler() {
    
    // Add nested struct buttons delegate event handler
    $('.console-content').delegate('.combobox', 'change', function () {
        updateRequest();
    });
    
    // Add nested struct buttons delegate event handler
    $('.console-content').delegate('.btn-add-struct', 'click', function() {

        var field = $(this).data('field');
        var type = $(this).data('type');
        var button = $(this);

        // Find the nested form for the field name and data type
        var count = 0;
        $(this).closest('div').find('.nested-message-param').each(function () {
            if ($(this).data('type') == type && $(this).data('field') == field)
                count++;
        });

        if (count == 4) {
            button.prop('disabled', true);
            button.next().prop('disabled', false);
        }

        // Find the parent div of the form with the add struct button
        count = 0;
        $(this).closest('div').find('.nested-message-param').each(function () {

            var item = $(this).parent().parent().is(":visible");

            // Show the form
            if ($(this).data('type') == type && $(this).data('field') == field) {

                if (count == 0 && !$(this).parent().parent().is(":visible")) {

                    $(this).parent().parent().show();
                    $(this).parent().show();

                    if ($(this).data('type').indexOf('[]') == -1) {
                        button.prop('disabled', true);
                    }
                    button.next().prop('disabled', false);
                    return false;
                }
                // Append new form for array item
                else {

                    // If type is part of an array
                    if ($(this).data('type').indexOf('[]') != -1) {
  
                        // Get the the container of the array item
                        var parent = $(this).parent().parent();

                        // Clone the parent div of the nested form
                        var item = $(this).parent().clone();

                        // Remove the title element
                        item.find('.form-type-name').remove();
                        item.find(':input').each(function () { $(this).val('') });

                        // Append struct to array item container
                        parent.append(item);
                    }

                    return false;
                }
            }
            // Continue 
            else {
                return true;
            }

            count++;
        });

        updateRequest();
        return false;
    });
        
    // Remove nested struct buttons delegate event handler
    $('.console-content').delegate('.btn-remove-struct', 'click', function () {

        // Get the field name and data type the button is associated with
        var field = $(this).data('field');
        var type = $(this).data('type');
        var button = $(this);

        // Find the nested form for the field name and data type
        var count = 0;
        $(this).closest('div').find('.nested-message-param').each(function () {
            if ($(this).data('type') == type && $(this).data('field') == field)
                count++;
        });

        if (count == 1) {
            button.prop('disabled', true);
            button.prev().prop('disabled', false);
        }

        $(this).closest('div').find('.nested-message-param').each(function () {

            if ($(this).data('type') == type && $(this).data('field') == field) {

                // Hide first nested form element
                if (count == 1) {
                    $(this).find(':input').each(function() { $(this).val('') });
                    $(this).parent().parent().hide();
                    $(this).parent().hide();
                    if ($(this).data('type').indexOf('[]') == -1) {
                        button.prop('disabled', true);
                        button.prev().prop('disabled', false);
                    }
                    return false;
                }
                // Remove additional array items
                else {

                    // If type is part of an array
                    if ($(this).data('type').indexOf('[]') != -1) {

                        // Get the the container of the array item
                        var parent = $(this).parent().parent();

                        // Remove the last array item
                        parent.find('div').last().remove();
                    }
                    return false;
                }
            }
        });

        updateRequest();
        return false;
    });
}

// Initialize click event handler for controller method menu items.
function initMenuHandler() {

    $('.console-menu-method').click(function () {

        // Get the id attribute of the menu item
        var id = $(this).attr('id');

        // Remove menu item selection
        $('.console-menu-method').each(function () {
            $(this).removeClass('method-selected');
        });

        // Highlight menu item 
        $(this).addClass('method-selected');

        var params = {
            action: 'method',
            request: $('.chk-real-request').prop('checked') ? 'real' : 'example',
            module: id.split('-')[0],
            controller: id.split('-')[1],
            method: id.split('-')[2]
        };

        jQuery.ajax({
            url: '/docs/console',
            data: params,
            dataType: 'html',
            success: function (data) {
                $('div.console-content').empty();
                $('div.console-content').html(data);
                $('div.console-content').find('.btn-remove-table').prop('disabled', true);
                $('.console-content').unbind();
                initFormHandler();
                initStructHandler();
                updateRequest();
            },
            error: function () {
            }
        });
    })
}

// Initialize change event handler for method parameter form input.
function initFormHandler() {

    // On parameter form input update request example
    $('.console-content').on('input', function (e) {
        updateRequest();
    });

    // Send request button
    $('.btn-send-request').click(function () {

        $(this).prop('disabled', true);

        if (validateForm())
            updateResponse();
        else
            $(this).prop('disabled', false);
    });


    // Add array item button
    $('.btn-add-table').click(function () {

        // Exit function if button is disabled
        var addBtn = $(this).parent().find('.btn-add-table')
        if (addBtn.hasClass('btn-disabled'))
            return;

        // Enable remove item button
        $(this).parent().find('.btn-remove-table').prop('disabled', false);

        // Get the class name of the container div
        var parentID = $(this).parent().parent().attr('class');

        // Get the parent div which contains the parameter form
        var item = $(this).parent().parent().clone();

        // Clear all text input on form
        item.find(':input').each(function () { $(this).val('') });

        // Remove add / remove item buttons
        item.find(".table-button-container").remove();

        // Remove nested struct array items
        item.find(".nested-struct-group").each(function () {

            $(this).hide();
            var count = 0;
            $(this).find("div").each(function () {
                if (count = 0) {
                    $(this).hide();
                }
                else {
                    $(this).remove();
                }
            });
        });

        // Insert after last array item
        item.insertAfter($('div.' + parentID + ':last'));

        // Get count of the number of array items
        var arrayLength = $('div.' + parentID).length;

        // Disable add button
        if (arrayLength == 10)
            addBtn.prop('disabled', true);

        updateRequest();
    });

    // Remove array item button
    $('.btn-remove-table').click(function () {

        // Exit function if button is disabled
        var removeBtn = $(this).parent().find('.btn-remove-table')
        if (removeBtn.hasClass('btn-disabled'))
            return;

        // Get the class name of the container div
        var parentID = $(this).parent().parent().attr('class');

        // Remove the last array item
        $('div.' + parentID + ':last').remove();

        // Get count of the number of array items
        var arrayLength = $('div.' + parentID).length;

        if (arrayLength == 1)
            removeBtn.prop('disabled', true);

        if (arrayLength == 9)
            $(this).parent().find('.btn-add-table').prop('disabled', false);

        updateRequest();
    });

}