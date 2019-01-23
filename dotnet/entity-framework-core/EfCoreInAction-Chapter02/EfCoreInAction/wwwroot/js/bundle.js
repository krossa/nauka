/**********************************************************************
 * LoggingDisplay handles the aquiring and display of the logs
 * 
 * First created: 2016/09/22
 * 
 * Under the MIT License (MIT)
 *
 * Written by Jon Smith : GitHub JonPSmith, www.thereformedprogrammer.net
 **********************************************************************/

var LoggingDisplay = (function($) {
    'use strict';

    var logApiUrl;
    var logs = null;
    var traceIdentLocal;

    var $showLogsLink = $('#show-logs');
    var $logModal = $('#log-modal');
    var $logModalBody = $logModal.find('.modal-body');
    var $logDisplaySelect = $logModal.find('#displaySelect');

    function getDisplayType() {
        return $logDisplaySelect.find('input[name=displaySelect]:checked').val();
    }

    function updateLogsCountDisplay() {
        var allCount = logs.requestLogs.length;
        $('.modal-title span').text(allCount);
        $('#all-select span').text(allCount);
        var sqlCount = 0;
        for (var i = 0; i < logs.requestLogs.length; i++) {
            if (logs.requestLogs[i].isDb) {
                sqlCount++;
            }
        }
        $('#sql-select span').text(sqlCount);
    }

    function showModal() {
        updateLogsCountDisplay();
        $logModal.modal();
    }

    function setContextualColors(eventType) {
        switch (eventType) {
            case 'Information':
                return 'text-info';
            case 'Warning':
                return 'text-warning';
            case 'Error':
                return 'text-danger';
            case 'Critical':
                return 'text-danger bold';
            default:
                return '';
        }
    }

    function fillModalBody() {
        var displayType = getDisplayType();
        var body = '<div class="panel-group" id="log-accordian" role="tablist" aria-multiselectable="true">';
        for (var i = 0; i < logs.requestLogs.length; i++) {
            if (displayType !== 'sql' || logs.requestLogs[i].isDb)
            body +=     
'<div class="panel panel-default">'+
   '<div class ="panel-heading" role="tab" id="heading'+i+'">'+
      '<h4 class ="panel-title text-overflow-dots">'+
        '<a role="button" data-toggle="collapse" data-parent="#log-accordion" href="#collapse' + i + '" aria-expanded="true" aria-controls="collapse' + i + '">' +
          '<span class="' + setContextualColors(logs.requestLogs[i].logLevel) + '">' + logs.requestLogs[i].logLevel + ':&nbsp;</span>'+
            logs.requestLogs[i].eventString + 
        '</a>'+
      '</h4>'+
    '</div>'+
    '<div id="collapse'+i+'" class ="panel-collapse collapse" role="tabpanel" aria-labelledby="heading'+i+'">'+
            '<div class ="panel-body white-space-pre">' + logs.requestLogs[i].eventString+''+
       '</div>'+
  '</div>'+
'</div>';
        }
        body += '</div>';
        $logModalBody.html(body);
    }

    function getLogs(traceIdentifier) {
        $.ajax({
            url: logApiUrl,
            data: { traceIdentifier: traceIdentifier }
        })
        .done(function (data) {
            logs = data;
            fillModalBody();
            showModal();
        })
        .fail(function () {
            alert("error");
        });
    }

    function startModal() {
        getLogs(traceIdentLocal);
    }

    function setupTrace(traceIdentifier, numLogs) {
        //now set up the log menu link
        traceIdentLocal = traceIdentifier;
        $showLogsLink.find('.badge').text(numLogs + '+');
    }

    //public parts
    return {
        initialise: function(exLogApiUrl, traceIdentifier, numLogs) {
            logApiUrl = exLogApiUrl;

            setupTrace(traceIdentifier, numLogs);

            //setup the events
            $showLogsLink.unbind('click')
                .bind('click',
                    function() {
                        startModal();
                    });
            $showLogsLink.removeClass('hidden');
            $logDisplaySelect.unbind('change')
                .bind('change',
                    function() {
                        fillModalBody();
                    });
        },

        newTrace: function(traceIdentifier, numLogs) {
            setupTrace(traceIdentifier, numLogs);
        }
    };
}(window.jQuery));
/**********************************************************************
 * BookList handles the book list, especially the 'filter by' part
 * 
 * First created: 2016/09/22
 * 
 * Under the MIT License (MIT)
 *
 * Written by Jon Smith : GitHub JonPSmith, www.thereformedprogrammer.net
 **********************************************************************/

var BookList = (function($, loggingDisplay) {
    'use strict';

    var filterApiUrl = null;

    function enableDisableFilterDropdown($fsearch, enable) {
        var $fvGroup = $('#filter-value-group');
        if (enable) {
            $fsearch.prop('disabled', false);
            $fvGroup.removeClass('dim-filter-value');
        } else {
            $fsearch.prop('disabled', true);
            $fvGroup.addClass('dim-filter-value');
        }
    }

    function loadFilterValueDropdown(filterByValue, filterValue) {
        filterValue = filterValue || '';
        var $fsearch = $('#filter-value-dropdown');
        enableDisableFilterDropdown($fsearch, false);
        if (filterByValue !== 'NoFilter') {
            //it is a proper filter val, so get the filter
            $.ajax({
                url: filterApiUrl,
                data: { FilterBy: filterByValue }
            })
                .done(function (indentAndResult) {
                    //This updates the logs with the trace from this
                    loggingDisplay.newTrace(indentAndResult.traceIdentifier, indentAndResult.numLogs);

                    //This removes the existing dropdownlist options
                    $fsearch
                        .find('option')
                        .remove()
                        .end()
                        .append($('<option></option>')
                            .attr('value', '')
                            .text('Select filter...'));

                    indentAndResult.result.forEach(function (arrayElem) {
                        $fsearch.append($("<option></option>")
                            .attr("value", arrayElem.value)
                            .text(arrayElem.text));
                    });
                    $fsearch.val(filterValue);
                    enableDisableFilterDropdown($fsearch, true);
                })
                .fail(function() {
                    alert("error");
                });
        }
    }

    function sendForm(inputElem) {
        var form = $(inputElem).parents('form');
        form.submit();
    }

    //public parts
    return {
        initialise: function(filterByValue, filterValue, exFilterApiUrl) {
            filterApiUrl = exFilterApiUrl;
            loadFilterValueDropdown(filterByValue, filterValue);
        },

        sendForm: function(inputElem) {
            sendForm(inputElem);
        },

        filterByHasChanged: function(filterElem) {
            var filterByValue = $(filterElem).find(":selected").val();
            loadFilterValueDropdown(filterByValue);
            if (filterByValue === "0") {
                sendForm(filterElem);
            }
        },

        loadFilterValueDropdown: function(filterByValue, filterValue) {
            loadFilterValueDropdown(filterByValue, filterValue);
        }
    };

}(window.jQuery, LoggingDisplay));