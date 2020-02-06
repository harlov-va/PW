/* global FormData */
import server from './server';

export async function all(){
    let response = await server.get('Values');
    return response;
}

export async function getDelivery(){
    let response = await server.get('Delivery');
    return response.data;
}

export async function sendOrder(payload){
    let response = await server.post('Values',JSON.stringify(payload));
    return response.status;
}

export async function sendXml(payload){
    let response = await server.post('Files',payload);
    return response.status;
}