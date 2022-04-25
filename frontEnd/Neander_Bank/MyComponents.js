import React from 'react';
import { StyleSheet, Text, View, FlatList, ScrollView, Button, Alert  } from 'react-native';


export default function MyComponents() {
    return (
        <View style={styles.container}>
            <View style = {styles.teste}>

            <Button
                title="New Text"
                onPress={() => {

                    // const getTrasitions = async () => {
                    //     try {
                        //         const response = await fetch(
                            //             'http://179.0.75.150:8080/api/transations'
                            //         );
                            
                            //         return await response;
                            //     } catch (error) {
                                //         console.error(error);
                                //     }
                                // };
                                // object = JSON.parse(getTrasitions());
                                // array = Object.keys(object).map(function (k) {
                                    //     return object[k];
                                    // });
                                    
                                    // Alert.alert(array[0])
                                    
                                    fetch('http://179.0.75.150:8080/api/transations')
                                    .then((response) => response.json())
                                    .then((json) => Alert.alert(json.toString()));
                                    
                                }}
                                />

            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: '#999',
        padding: 0,
        margin: 4,
        justifyContent: 'center',
        alignContent:'center',
        color: '#ebf3e7',
        alignItems:'center',
    },
    teste: {
        alignContent:'center',
        alignItems:'center',
        justifyContent: 'center',
        
    }
});
