
//// maybe remove above
use curl::easy::Easy;

use std;
use serde_json;
use serde_json::{Value, Map};

#[derive(Serialize, Deserialize, Debug)]
pub struct Price {
    pub date: String,
    pub price: i64,
}

pub fn get_current_item_price(item_id: i64) -> String {
    let url = get_item_url(item_id);
    let json = get_raw_json(&url);

    let v: Value = serde_json::from_str(&json).unwrap();
    let price: String = v["item"]["current"]["price"].to_string();
    return price;
}
 
pub fn get_item_price_history(item_id: i64) -> Vec<Price> {
    let url = get_item_history_url(item_id);

    std::thread::sleep(std::time::Duration::from_millis(5000));
    let json = get_raw_json(&url);

    let v2: Map<String, Value> = serde_json::from_str(&json).expect(&url);
    let daily = v2.get("daily").unwrap();

    let oo: &Map<String, Value> = daily.as_object().unwrap();
    
    let mut prices: Vec<Price> = Vec::new();
    for v in oo.iter() {
        let tup: &(&String, &Value) = &v;
        prices.push(Price {
            date: tup.0.to_string(),
            price: tup.1.as_i64().unwrap(),
        });
    }

    return prices;
}

pub fn get_item_history_url(item_id: i64) -> String {
    let url = format!("http://services.runescape.com/m=itemdb_oldschool/api/graph/{}.json", item_id);
    //let url = format!("file:///home/ben/rust/getracker/src/res/{}.json", item_id);
    return url;
}

fn get_item_url(item_id: i64) -> String {
    let mut url = String::from("http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=");
    let s = item_id.to_string();

    url.push_str(&s);
    return url;
}

pub fn get_raw_json(url: &str) -> String {
    let mut html: String = String::new();
    {
	let mut easy = Easy::new();
 	easy.url(url).unwrap();

	let mut transfer = easy.transfer();
	transfer.write_function(|data| {
		html.push_str(std::str::from_utf8(data).unwrap());          
		Ok(data.len())
		}).unwrap(); 

	transfer.perform().unwrap();
    }
    return html;
}

