$.prototype.backupDashboard = function (items) {

    var self = this;

    // this field contains thresholdMap to find appropriate style according to value
    var valueStylesMap = function () {

        // 1. this logic iterates through whole bunch of css rules (rather expencive but we will do it once) 
        // 2. it takes all rules which starts from mark ".less_then_"
        // 3. it parse the rest of a selectorText extracts percentage value
        // 4. it adds the value into associative array where value is a key e.g.  result[100] = .less_then_100  
        // 5. to find appropriate class name for percantage value we will iterate through keys of the associative array and take class name by found key 
        var result = [];

        var cssRulesCommonName = ".less_then_";

        for (var i = 0; i < document.styleSheets.length; i++) {
            var rules = document.styleSheets[i].rules || document.styleSheets[i].cssRules;
            for (var x = 0; x < rules.length; x++) {
                if (rules[x].selectorText && rules[x].selectorText.indexOf(cssRulesCommonName) == 0) {
                    result[rules[x].selectorText.substring(cssRulesCommonName.length)] = rules[x].selectorText.substring(1);
                }
            }
        }

        return result;
    }();

    var getValueCss = function (val) {
        // Here we iterate through collection of keys of thresholdMap untill the value is less then key
        // Here I relay on fact that keys are already sorted in ascending order so sorting is not necessary
        for (var key in valueStylesMap) {

            if (val < key) {
                return valueStylesMap[key];
            }
        }
        return valueStylesMap[key];
    }

    var renderValue = function (container, value) {

        // this function renders content as span element
        var valContainer = document.createElement('span');
        valContainer = $(valContainer)
        valContainer.append(value.toFixed(2));
        valContainer.addClass(getValueCss(value))

        $(container).append(valContainer)
    }

    // calculate average here;
    var avgValue = items.reduce(function (sum, current, index) {
        return sum + current;
    }, 0) / items.length;


    // render average value into dedicated block element
    var averageContainer = $('<div class="average"></div>')
    renderValue(averageContainer, avgValue);

    var detailedContainer = $('<div class="detailed"></div>');

    // render detailed statistics into dedicated block element
    items.forEach(
        function (value) {
            renderValue(detailedContainer, value);
        });

    // here we add renderrings into parent
    $(self).append(averageContainer, detailedContainer)
};
