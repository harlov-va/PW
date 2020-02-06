import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

import ProductList from './components/ProductsList';
import Product from './components/Product';
import Cart from './components/Cart';
import E404 from './components/E404';
import Checkout from './components/Checkout';
import Admin from './components/Admin';



import {store} from './store';

const routes = [
	{
		path: '',
		redirect: {name: 'products'}
	},
	{
		name: 'products',
		path: '/products',
		component: ProductList,
		beforeEnter(from, to, next){
			store.commit('checkout/onSubmited',false);
			next();
		}
	},
	{
		path: '/products/:id',
		component: Product
	},
	{
		path: '/cart',
		component: Cart,
		beforeEnter(from, to, next){
			store.commit('checkout/onSubmited',false);
			next();
		}
	},
	{
		path: '/admin',
		component: Admin,
		beforeEnter(from, to, next){
			store.commit('checkout/onSubmited',false);
			next();
		}
	},
	{
		path: '/checkout',
		component: Checkout
	},
	{
		path: '*',
		component: E404
	}
];

export const router = new VueRouter({
	routes,
	mode: 'history'
});