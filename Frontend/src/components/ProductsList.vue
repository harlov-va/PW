<template>
	<div>
		<h1>Products</h1>
		<div class="row">
			<div class="col col-sm-4" 
			     v-for="product in products">
				 <div class="well">
						<router-link tag="h3" :to="'/products/' + product.id_product">
						<a>{{ product.title }}</a>
						</router-link>
						<div>{{ product.price }}</div>
						<button v-if="inCart.indexOf(product.id_product) === -1"
								@click="addToCart(product.id_product)"
								class="btn btn-primary"
								>
							Add to cart
						</button>
						<button v-else
								@click="removeFromCart(product.id_product)"
								class="btn btn-warning"
						>
							Remove to cart
						</button>						
				 </div>
			</div>
		</div>
	</div>
</template>

<script>
	import {mapGetters} from 'vuex';
	import {mapActions} from 'vuex';

	export default {
		created(){
			this.$store.dispatch('products/loadItems');
		},
		computed: {
			...mapGetters('products', {
				products: 'items'
			}),
			...mapGetters('cart', {
				inCart: 'products'
			})
		},
		methods: {
			...mapActions('cart', {
				addToCart: 'add',
				removeFromCart: 'remove'
			})
		}
	}
</script>

<style scoped>
	.row{
		padding-left: 15px;
	}
</style>