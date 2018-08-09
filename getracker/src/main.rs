extern crate curl;
extern crate serde;
extern crate serde_json;
extern crate regex;

#[macro_use]
extern crate serde_derive;
extern crate chrono;

extern crate select;
extern crate reqwest;

use chrono::prelude::*;
use std::fs::File;

use std::io::{BufReader, BufRead};
use std::collections::HashMap;

mod ge_api;
mod top100_api;

fn epoch_to_timestamp(epoch_usec: i64) -> String {
    let ndt = NaiveDateTime::from_timestamp(epoch_usec/1000,0);
    let dt: DateTime<Utc> = DateTime::from_utc(ndt, Utc);

    return dt.to_rfc3339();
}

fn read_items_from_file(filename: &str) -> Vec<i64> {
    let mut items: Vec<i64> = Vec::new();

    let file = File::open(filename).unwrap();
    for line in BufReader::new(file).lines() {
        items.push(line.unwrap().trim().parse::<i64>().unwrap());
    }

    return items;
}

fn get_daily_price_sum(item_ids: Vec<i64>) -> Vec<ge_api::Price> {
    let mut sums: HashMap<String, i64> = HashMap::new();
    for id in &item_ids {
        for p in ge_api::get_item_price_history(*id) {
            let price_sum = sums.entry(p.date.to_string()).or_insert(0);
            *price_sum += p.price;
        }
    }

    // get single list of epochs for use in lookup
    let prices = ge_api::get_item_price_history(*item_ids.get(0).expect("item id list was empty!"));
    let mut epochs: Vec<String> = Vec::new();
    for p in prices {
        epochs.push(p.date);
    }
    
    let mut sum_history: Vec<ge_api::Price> = Vec::new();
    for e in epochs {
        sum_history.push(ge_api::Price { date: e.clone(), price: *sums.get(&e).unwrap() });
    }

    return sum_history;
}

fn main() {
   /*
    let item_id = 4151;
   
    let price = get_current_item_price(item_id);
    println!("{}", price);

    for p in get_item_price_history(item_id) {
        let t: i64 = p.date.parse().unwrap();
        println!("{}, {}", epoch_to_timestamp(t), p.price);
    }
    */

    //let item_ids = read_items_from_file("./res/items.txt");

    let most_traded_items = top100_api::top100("http://services.runescape.com/m=itemdb_oldschool/top100");
    let market_history = get_daily_price_sum(most_traded_items);
    for p in market_history {
        println!("{},{}", epoch_to_timestamp(p.date.parse().unwrap()), p.price);
    }

}

