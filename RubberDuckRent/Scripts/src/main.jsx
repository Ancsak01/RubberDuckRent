import { Duck } from './Ducks/ducks-component'

class Main extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <main>
                <Switch>
                    <Route path="/temp" component={Duck} />
                </Switch>
            </main>
            )
    }
}

ReactDOM.render(<Main />, document.getElementById('mainContainer'));