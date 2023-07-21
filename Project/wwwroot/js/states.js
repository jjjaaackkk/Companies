function get_states()
{
    return {
        'al': 'Alabama',
        'ak': 'Alaska',
        'az': 'Arizona',
        'ar': 'Arkansas',
        'ca': 'California',
        'co': 'Colorado',
        'ct': 'Connecticut',
        'de': 'Delaware',
        'dc': 'District of Columbia',
        'fl': 'Florida',
        'ga': 'Georgia',
        'hi': 'Hawaii',
        'id': 'Idaho',
        'il': 'Illinois',
        'in': 'Indiana',
        'ia': 'Iowa',
        'ks': 'Kansas',
        'ky': 'Kentucky',
        'la': 'Louisiana',
        'me': 'Maine',
        'md': 'Maryland',
        'ma': 'Massachusetts',
        'mi': 'Michigan',
        'mn': 'Minnesota',
        'ms': 'Mississippi',
        'mo': 'Missouri',
        'mt': 'Montana',
        'ne': 'Nebraska',
        'nv': 'Nevada',
        'nh': 'New Hampshire',
        'nj': 'New Jersey',
        'nm': 'New Mexico',
        'ny': 'New York',
        'nc': 'North Carolina',
        'nd': 'North Dakota',
        'oh': 'Ohio',
        'ok': 'Oklahoma',
        'or': 'Oregon',
        'pa': 'Pennsylvania',
        'ri': 'Rhode Island',
        'sc': 'South Carolina',
        'sd': 'South Dakota',
        'tn': 'Tennessee',
        'tx': 'Texas',
        'ut': 'Utah',
        'vt': 'Vermont',
        'va': 'Virginia',
        'wa': 'Washington',
        'wv': 'West Virginia',
        'wi': 'Wisconsin',
        'wy': 'Wyoming'
    };
}

function get_state(code)
{
    if ('undefined' === code) return ''

    code = code.toLowerCase();
    var states = get_states();

    try {
        return states[code]
    }
    catch (e) {
        return ''
    }
}

function getKeyByValue(object, value)
{
    return Object.keys(object).find(key => object[key] === value);
}

function get_state_code(state)
{
    var states = get_states();
    var key = getKeyByValue(states, state);

    return key
}