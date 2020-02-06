export default {
	namespaced: true,
	state: {
		products: [],
		amountProducts:[]
	},
	getters: {
		products(state){
			return state.products;
		},
		cnt(state){
			return state.products.length;
		},
		amountProducts(state){
			return state.amountProducts;
		}
	},
	mutations: {
		add(state, id_product){
			if(state.products.indexOf(id_product) === -1){
				state.products.push(id_product);
				state.amountProducts.push(1);
			}
		},
		remove(state, id_product){
			let pos = state.products.indexOf(id_product);

			if(pos !== -1){
				state.products.splice(pos, 1);
				state.amountProducts.splice(pos, 1);
			}
		},
		removeAll(state){
			state.products = [];
			state.amountProducts = [];
		},
		changeValue(state,payload){
			state.amountProducts[payload.index] = payload.value;
		}
	},
	actions: {
		add(store, id_product){
			store.commit('add', id_product);
		},
		remove(store, id_product){
			store.commit('remove', id_product);
		},
		removeAll(store){
			store.commit('removeAll');
		}
	}
};