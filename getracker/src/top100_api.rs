use select::document::Document;
use select::predicate::{Class, Name, Predicate};

use reqwest;
use regex::Regex;

pub fn top100(url: &str) -> Vec<i64> {
    let resp = reqwest::get(url).unwrap();
    assert!(resp.status().is_success());

    let l: Document = Document::from_read(resp).unwrap();
    let f = l.find(Name("a"));
    let fm = f.filter_map(|n| n.attr("href"));

    let urls: Vec<_> = fm.collect();

    let mut item_ids: Vec<i64> = Vec::new();
    for u in urls {
        if u.contains("viewitem?obj=")  {
            let item_id_idx = u.find("obj=").unwrap();
            let item_id: i64 = u.get(item_id_idx+4..u.len()).unwrap().parse().unwrap();
            item_ids.push(item_id);
        }
    }

    item_ids.sort();
    item_ids.dedup();

    return item_ids;
}

