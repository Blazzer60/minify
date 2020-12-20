import React, { Component } from 'react';
import { Redirect } from 'react-router'

export class Add extends Component {
    constructor(props) {
        super(props);
        this.state = {value: ''};

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({value: event.target.value});
    }

    async handleSubmit(event) {
        event.preventDefault();
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ url: this.state.value })
        };
        const response = await fetch('minify', requestOptions);
        this.setState({ redirect: true })
    }

    render() {
        const { redirect } = this.state;

        if (redirect) {
            return <Redirect to='/'/>;
        }
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Url : <input type="text" value={this.state.value} onChange={this.handleChange} />
                </label>
                <input type="submit" value="Envoyer" />
            </form>
            );
    }
}