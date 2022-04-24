import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, Text, View, FlatList, ScrollView, Button, Pressable, onPressFunction,  } from 'react-native';

import MyComponents from './MyComponents';

export default function App() {
  return (

    <View style={styles.container}>
      <StatusBar style="light" />
      <Text style={styles.title}> NEANDER BANK </Text>
      <View style={styles.teste}>
        <ScrollView>
         
        </ScrollView>
      </View>

    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#E0E0E0',
    alignItems: 'center',
    paddingTop: 40,
    fontSize: 150,
    textAlign: 'center',

    // justifyContent: 'center',
  },
  title: {
    color: 'black',
    fontSize: 30,
  },
});
