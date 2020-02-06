<template>
	<div>
		<h1>Загрузить товары</h1>
		<button 						
			class="btn btn-primary"
			>
			{{ textButton }}
		</button>
	</div>
</template>

<script>
	import {mapActions} from 'vuex';
	import {mapGetters} from 'vuex';
	export default {
		data(){
			return{
				textButton:'Add goods'
			}
		},
		computed: {
			id(){
				return this.$route.params.id;
			},
			product(){
				return this.$store.getters['products/item'](this.id);
			},
			...mapGetters('cart', {
				inCart: 'products'
			}),
			// isDisabled(){
			// 	if (this.inCart.indexOf(this.product.id_product) === -1){
			// 		this.textButton = 'Add goods';
			// 		return false;
			// 	}
			// 	else {
			// 		this.textButton = 'A product in cart';
			// 		return true;
			// 	}
			// }
		},
		methods: {
			...mapActions('cart', {
				addToCart: 'add',
				removeFromCart: 'remove'
			})
		}
	}
</script>