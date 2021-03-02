select pr.name, cat.name from products pr
full join category_product cat_pr on pr.id = cat_pr.product_id
full join categories cat on cat.id = cat_pr.category_id

