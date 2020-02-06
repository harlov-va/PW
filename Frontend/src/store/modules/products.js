import Vue from 'vue';
import * as productModel from './articles';

export default {
	namespaced: true,
	state: {
		items: [] //getProducts()
	},
	getters: {
		items(state){
			return state.items;
		},
		itemsMap(state){
			let itemsMap = {};

			for(let i = 0; i < state.items.length; i++){
				let product = state.items[i];
				itemsMap[product.id_product] = product;
			}

			return itemsMap;
		},
		item: (state, getters) => (id) => {
			return getters.itemsMap[id];
		}
	},
	mutations: {
		clearItems(state){
			state.items = [];
		},
		loadItems(state, data){
			state.items = data;
		}
	},
	actions: {
		loadItems(store){
			store.commit('clearItems');
			productModel.all().then((response) =>{
				if(response.status === 200){
					store.commit('loadItems', JSON.parse(response.data));
				}
				else{
					store.dispatch('error/changeStateComment',{state: false, text: 'Products not received'},{ root: true });
				}

			}).catch(() => {
				store.dispatch('error/changeStateComment',{state: false, text: 'Products not received'},{ root: true });
			});

		}
	}
};


// function getProducts(){
// 	return [
// 		{
// 			id_product: 10,
// 			title: 'Iphone 5',
// 			price: 20000
// 		},
// 		{
// 			id_product: 20,
// 			title: 'Iphone 6',
// 			price: 25000
// 		},
// 		{
// 			id_product: 30,
// 			title: 'Iphone 7',
// 			price: 30000
// 		}
// 	]
// };
